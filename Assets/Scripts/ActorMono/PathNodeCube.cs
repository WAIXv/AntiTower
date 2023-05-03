using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class PathNodeCube : MonoBehaviour
{
    [SerializeField] protected PathNodeCube defaultNextCube;
    [SerializeField] private bool _isLevelStartCube = false;
    
    [ShowIf("_isLevelStartCube")] 
    [SerializeField] private GameManager _gameManager;
    
    public bool IsEndPoint => defaultNextCube == null;
    public Vector3 Direction => NextCube.transform.position - transform.position;
    public PathNodeCube NextCube
    {
        get => defaultNextCube;
        set => defaultNextCube = value;
    }

    private void OnEnable()
    {
        if (_isLevelStartCube) 
            _gameManager.LevelStartCube = this;
    }
}
