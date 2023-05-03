using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActorMono
{
    public class SwitchCube : MonoBehaviour
    {
        [SerializeField] private List<SwapNodeCube> _controlledCubeList;
        [SerializeField] private GameObject _baseYG;
        [SerializeField] private GameObject _redYG;
        [SerializeField] private GameObject _greenYG;

        private Collider _collider;
        private bool _turning = false;
        private bool _currentState = true;
        private float _targetAngle;
        private float _currentAngle;
        float _step = 3f;

        private void Awake()
        {
            _currentAngle = _baseYG.transform.localRotation.eulerAngles.z;
            _collider = GetComponent<Collider>();
        }
        
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) 
                return;
            
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, 100f);
            if (hit.collider == _collider)
                SwapControllingCubes();
        }
        
        private void SwapControllingCubes()
        {
            _currentState = !_currentState;
            if (!_turning)
                StartCoroutine(RotateSwitch());
        }

        private IEnumerator RotateSwitch()
        {
            _turning = true;
            _targetAngle = _currentState ? 10f : -60f;
            while (Math.Abs(_currentAngle - _targetAngle) > .1f)
            {
                _targetAngle = _currentState ? 10f : -60f;
                _currentAngle = Mathf.MoveTowardsAngle(_currentAngle,_targetAngle, _step);
                _baseYG.transform.localRotation = Quaternion.Euler(0,0,_currentAngle);
                yield return null;
            }
            
            foreach (var cube in _controlledCubeList)
            {
                cube.ChangeNextCube();
            }
            _turning = false;
            _redYG.SetActive(_currentState);
            _greenYG.SetActive(!_currentState);
        }
    }
}