using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTexture : MonoBehaviour
{
    //Variables
    Color color = Color.green;
    Renderer rend;

    float brightness = 0f;
    public float scrollSpeed = 1f;
    public float brightnessSpeed = 2.5f;
    private int reverse = -1;


    void Start()
    {
        rend = GetComponent<Renderer>();
        brightnessSpeed *= 0.002f;
    }


    //Update is called once per frame
    void Update ()
    {
        //Go from up to down.
        brightness += brightnessSpeed * reverse;
        if(brightness >= 0.15f || brightness  <= -0.35f)
        {
            reverse *= -1;
        }

        //Set new emissions.
        GetComponent<Renderer>().material.color = color;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color * brightness);

        //Set scroll speed on lava.
        scrollSpeed -= 1 * Time.deltaTime * 0.2f;
        rend.material.SetTextureOffset("_MainTex", new Vector2(scrollSpeed, 0));
    }
}
