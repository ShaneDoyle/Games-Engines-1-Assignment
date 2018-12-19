using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLava : MonoBehaviour
{
    //Variables
    Color Color = Color.green;
    Renderer rend;

    //Lava settings.
    float Brightness = -0.20f;
    public float LavaSpeed;
    public float BrightnessSpeed;

    //Built in.
    private int Reverse = -1;
    private float ScrollSpeed;

    //Initialisation.
    void Start()
    {
        rend = GetComponent<Renderer>();
        BrightnessSpeed *= 0.002f;
    }

    //Update lava.
    void Update ()
    {
        //Go from up to down.
        Brightness += BrightnessSpeed * Reverse;
        if(Brightness >= 0.05f || Brightness <= -0.40f)
        {
            Reverse *= -1;
        }

        //Set new emissions.
        GetComponent<Renderer>().material.color = Color;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", Color * Brightness);

        //Set scroll speed on lava.
        ScrollSpeed -= 1 * Time.deltaTime * 0.20f * LavaSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(ScrollSpeed, 0));
    }
}
