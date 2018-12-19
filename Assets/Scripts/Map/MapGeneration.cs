using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    //Land Variables.
    int HeightScale;
    float DetailScale;

    //Initialisation.
    void Awake()
    {
        GameObject GV = GameObject.Find("Global Variables");
        HeightScale = GV.GetComponent<GlobalVariables>().HeightScale;
        DetailScale = GV.GetComponent<GlobalVariables>().DetailScale;

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        for (int v = 0; v < vertices.Length; v++)
        {
            vertices[v].y = Mathf.PerlinNoise((vertices[v].x + this.transform.position.x) / DetailScale,
                                                (vertices[v].z + this.transform.position.z) / DetailScale) * HeightScale;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.gameObject.AddComponent<MeshCollider>();
    }
}
