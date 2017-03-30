using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexTest : MonoBehaviour {
    public float multiplier = 0.1f;

	void Start () {
		
	}

    void Update()
    {
        Mesh mesh = GetComponentInChildren<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        int i = 0;
        while (i < vertices.Length)
        {
            vertices[i] += normals[i] * Mathf.Sin(Time.time) * multiplier;
            i++;
        }
        mesh.vertices = vertices;
    }

}
