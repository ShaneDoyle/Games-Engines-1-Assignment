using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlane : MonoBehaviour
{
    public float WaitToAppear;

    GameObject GV;
    bool PlayPopSound;

    //Use this for initialization
    void Start()
    {
        transform.Translate(0, 20, 0);
        StartCoroutine(Appear());
        GV = GameObject.Find("Global Variables");
        PlayPopSound = GV.GetComponent<GlobalVariables>().PlayPopSound;
    }

    //Update is called once per frame
    void Update()
    {

    }

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
