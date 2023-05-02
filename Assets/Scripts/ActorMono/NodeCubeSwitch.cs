using System;
using System.Collections.Generic;
using UnityEngine;

namespace ActorMono
{
    public class NodeCubeSwitch : MonoBehaviour
    {
        [SerializeField] private List<SwapNodeCube> _controlledCubeList;

#if UNITY_EDITOR
        [SerializeField] private bool testToggle;

        private void TestInUpdate()
        {
            if (testToggle)
            {
                SwapControllingCubes();
            }
        }

        private void Update()
        {
            TestInUpdate();
        }
#endif

        private void SwapControllingCubes()
        {
            foreach (var cube in _controlledCubeList)
            {
                cube.ChangeNextCube();
            }
        }
    }
}