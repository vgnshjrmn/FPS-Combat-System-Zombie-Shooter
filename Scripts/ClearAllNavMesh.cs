using UnityEngine;
using UnityEngine.AI;

public class ClearAllNavMesh : MonoBehaviour
{
    void Start()
    {
        NavMesh.RemoveAllNavMeshData();
        Debug.Log("All NavMesh data cleared");
    }
}
