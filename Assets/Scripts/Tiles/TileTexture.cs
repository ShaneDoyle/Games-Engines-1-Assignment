using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTexture : MonoBehaviour
{


    Color color = Color.green;
    float f = 0.4f;
    private int reverse = -1;


    //Use this for initialization
    void Start ()
    {

    }
	
	//Update is called once per frame
	void Update ()
    {
        f += 0.005f * reverse;
        if(f >= 0.5f || f<= -0.25f)
        {
            reverse *= -1;
        }

        GetComponent<Renderer>().material.color = color;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color * f);
    }
}
