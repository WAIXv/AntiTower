using UnityEngine;
using UnityEngine.Serialization;

public class PathNodeCube : MonoBehaviour
{
    [SerializeField] private PathNodeCube defaultNextCube;
    
    public bool IsEndPoint => defaultNextCube == null;
    public Vector3 Direction => NextCube.transform.position - transform.position;
    public PathNodeCube NextCube
    {
        get => defaultNextCube;
        set => defaultNextCube = value;
    }
}
