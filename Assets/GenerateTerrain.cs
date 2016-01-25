using UnityEngine;
using System.Collections;

public class GenerateTerrain : MonoBehaviour
{
    static readonly int[] triangle_indices = { 0, 2, 1, 2, 0, 3 };
    static readonly Vector3[] vertices = {
        new Vector3(-10 , 0 , -10),
        new Vector3(10  , 0 , -10),
        new Vector3(10  , 0 , 10 ),
        new Vector3(-10 , 0 , 10 ),
    };



    void make_square()
    {
        GameObject go = new GameObject();
        go.name = "square";
        go.transform.localPosition = new Vector3(-10, 0, 20);

        MeshFilter mf = go.AddComponent<MeshFilter>();
        go.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangle_indices;
        mf.mesh = mesh;
    }

    // Use this for initialization
    void Start () {
        make_square();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
