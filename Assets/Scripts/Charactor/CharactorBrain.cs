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

        private void Awake()
        {
            GetComponent<Damageable>()._initHealth = data.InitHealth;
            
            OnArrived += () =>
            {
                Debug.Log($"{gameObject.name} Arrived");
                data.CharactorArrivedEvnet.RaiseEvent(data.costValue);
            };
        }
    }
}