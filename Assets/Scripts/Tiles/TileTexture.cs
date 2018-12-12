using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTexture : MonoBehaviour
{
    //Variables
    Color color = Color.green;
    float f = 0f;
    private int reverse = -1;

    Renderer rend;
    public float scrollSpeed = 1f;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    //Update is called once per frame
    void Update ()
    {
        //Go from up to down.
        f += 0.005f * reverse;
        if(f >= 0.25f || f<= -0.25f)
        {
            reverse *= -1;
        }

        //Set new emissions.
        GetComponent<Renderer>().material.color = color;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color * f);

        //
        scrollSpeed -= 1 * Time.deltaTime * 0.2f;
        rend.material.SetTextureOffset("_MainTex", new Vector2(scrollSpeed, 0));
    }
}
