using UnityEngine;

namespace ActorMono
{
    public class FaceToCamMono : MonoBehaviour
    {
        [SerializeField] private bool LockXRot = true;

        private float _originXRot;
        private Transform _camTrans;
        private Vector3 _targetRot;
        
        private void Awake()
        {
            _camTrans = Camera.main.transform;
            _originXRot = transform.rotation.eulerAngles.x;
        }
        
        private void Update()
        {
            transform.LookAt(_camTrans.position - _camTrans.forward * 1000f);
            if (LockXRot)
                transform.rotation = Quaternion.Euler(-_originXRot, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
    }
}