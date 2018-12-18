using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{

    //Land Variables.
    int heightScale;
    float detailScale;

    // Use this for initialization
    void Awake()
    {
        GameObject go = GameObject.Find("Global Variables");
        heightScale = go.GetComponent<GlobalVariables>().heightScale;
        detailScale = go.GetComponent<GlobalVariables>().detailScale;

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int v = 0; v < vertices.Length; v++)
        {
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / detailScale,
                                                (vertices[v].z + this.transform.position.z) / detailScale) * heightScale;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();
    }
}
