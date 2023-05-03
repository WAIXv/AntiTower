using System;
using UnityEngine;
using UnityEngine.AI;

namespace Charactor
{
    public class Enemy_01 : MonoBehaviour
    {
        [Header("Normal Attack")]
        [SerializeField] private float _detectRange;
        [SerializeField] private CapsuleCollider _detectArea;
        [SerializeField] private int _attackValue;
        [SerializeField] private float _attackInterval;

        [Header("Patrol")] 
        [SerializeField] private Transform _startPoint;

        private Transform _target;
        private Damageable _targetDamageable;
        private NavMeshAgent _agent;
        private bool targetLocked = false;
        private bool movingWithTarget = false;
        private float _prevoiusAttack;
        private float _prevoiusDistance;
        private Vector3 _followOffset;

        private void Awake()
        {
            _detectArea.radius = _detectRange;
            _agent = GetComponent<NavMeshAgent>();
            _agent.Warp(transform.position);
        }

        private void Update()
        {
            if(targetLocked)
            {
                if (Time.time - _prevoiusAttack > _attackInterval)
                {
                    _prevoiusAttack = Time.time;
                    DoAttack();
                }
                
                if (_targetDamageable.IsDead)
                {
                    targetLocked = false;
                    _target = null;
                    _targetDamageable = null;
                    return;
                }

                _agent.destination = _target.transform.position;
            }
            else
            {
                _agent.destination = _startPoint.position;
            }
        }

        private void DoAttack()
        {
            _targetDamageable.ReceiveAnAttack(_attackValue);
            
        }

        private void MoveWithTarget()
        {
            transform.position = _target.position + _followOffset;
        }

        public void OnCharactorEnter(bool enable, GameObject other)
        {
            if(enable)
            {
                if(targetLocked) return;
                
                _target = other.transform;
                _targetDamageable = other.GetComponent<Damageable>();
                targetLocked = true;
                Debug.Log($"Lock {_target.gameObject.name}");

                _prevoiusDistance = Vector3.Distance(transform.position, _target.position);
            }
            else if(other == _target.gameObject)
            {
                Debug.Log($"Unlock {_target.gameObject.name}");
                targetLocked = false;
                _target = null;
                _targetDamageable = null;
            }

        }
    }
}