using System;
using UnityEngine;
using UnityEngine.Events;

namespace Charactor
{
    public class CharactorBrain : MonoBehaviour
    {
        public CharactorDataSO data;
        public PathNodeCube CurrentCube { get; set; }
        public Vector3 movementVector { get; set; }
        public bool Arrived { get; set; }
        
        public UnityAction OnArrived = delegate { };

        private Damageable _damageable;

        private void Awake()
        {
            _damageable = GetComponent<Damageable>();
            _damageable._initHealth = data.InitHealth;
            
            OnArrived += () =>
            {
                Debug.Log($"{gameObject.name} Arrived");
                data.CharactorArrivedEvnet.RaiseEvent(data.costValue);
                _damageable.IsDead = true;
                _damageable.SelfDestroy();
            };
        }
    }
}