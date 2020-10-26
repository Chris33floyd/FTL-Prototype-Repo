using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Mesh mesh = new Mesh();

		Vector3[] vertices = new Vector3[3];
		Vector2[] uv = new Vector2[3];
		int[] triangles = new int[3];

		mesh.vertices = vertices;
		mesh.uv = uv;
		mesh.triangles = triangles;

		GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
