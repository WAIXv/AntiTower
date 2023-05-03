using System;
using UnityEngine;

namespace Charactor
{
    public class CharactorBrain : MonoBehaviour
    {
        [SerializeField] private PathNodeCube startCube;
        
        public CharactorDataSO data;
        public PathNodeCube CurrentCube { get; set; }

        public Vector3 movementVector;

        public bool Arrived { get; set; }

        private void OnEnable()
        {
            CurrentCube = startCube;
            transform.position = CurrentCube.transform.position;
        }
    }
}