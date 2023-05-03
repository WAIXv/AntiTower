using System;
using System.Collections.Generic;
using UnityEngine;


public class SwapNodeCube : PathNodeCube
{
    [Header("Swap Node")] 
    [SerializeField] private List<PathNodeCube> nextCubeList;

    private Transform _meshTrans;
    private int _curIndex = 0;

    private void Awake()
    {
        _meshTrans = transform.GetChild(0);
        _meshTrans.right = Direction;
    }

    private void OnEnable()
    {
        NextCube = nextCubeList[_curIndex];
    }

    public void ChangeNextCube()
    {
        _curIndex++;
        if(_curIndex == nextCubeList.Count) _curIndex = 0;
        NextCube = nextCubeList[_curIndex];
        _meshTrans.right = Direction;
    }
}
