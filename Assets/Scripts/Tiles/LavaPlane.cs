using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlane : MonoBehaviour
{
    //Variables.
    public float WaitToAppear; //Time to "pop" into the game.

    //Built in variables.
    GameObject GV;
    bool PlayPopSound;

    //Initialisation.
    void Start()
    {
        transform.Translate(0, 20, 0);
        StartCoroutine(Appear());
        GV = GameObject.Find("Global Variables");
        PlayPopSound = GV.GetComponent<GlobalVariables>().PlayPopSound;
    }

    //Appear into game.
    IEnumerator Appear()
    {
        yield return new WaitForSeconds(WaitToAppear);
        transform.Translate(0, -20, 0);

        //Play sound only once.
        PlayPopSound = GV.GetComponent<GlobalVariables>().PlayPopSound;
        if(PlayPopSound == true )
        {
            FindObjectOfType<AudioManager>().Play("Pop");
            GV.GetComponent<GlobalVariables>().PlayPopSound = false;
        }

    }
}
