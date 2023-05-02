using System;
using System.Collections.Generic;
using UnityEngine;


public class SwapNodeCube : PathNodeCube
{
    [Header("Swap Node")] 
    [SerializeField] private List<PathNodeCube> nextCubeList;

    private int _curIndex = 0;
    
#if UNITY_EDITOR
    [SerializeField] public bool toggle;
#endif

    private void OnEnable()
    {
        NextCube = nextCubeList[_curIndex];
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (toggle)
        {
            ChangeNextCube();
            toggle = false;
        }
#endif
    }

    public void ChangeNextCube()
    {
        _curIndex++;
        if(_curIndex == nextCubeList.Count) _curIndex = 0;
        NextCube = nextCubeList[_curIndex];
    }
}
