using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyGenerator : MonoBehaviour
{
    public Mesh[] meshes;
    private MeshFilter mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>();

        mesh.mesh = meshes[Random.Range(0, meshes.Length - 1)];
    }
}
