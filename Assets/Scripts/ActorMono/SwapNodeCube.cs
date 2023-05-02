using System;
using UnityEngine;


public class SwapNodeCube : PathNodeCube
{
    [Header("Swap Node")]
    [SerializeField] private PathNodeCube nextCube_on;
    [SerializeField] private PathNodeCube nextCube_off;

    [SerializeField] private bool toggle;

    public void ChangeNextCube()
    {
        toggle = !toggle;
        NextCube = toggle ? nextCube_on : nextCube_off;
    }

    private void OnEnable()
    {
        ChangeNextCube();
    }
}
