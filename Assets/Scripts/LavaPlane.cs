using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlane : MonoBehaviour
{
    public float WaitToAppear;

    GameObject GV = GameObject.Find("Global Variables");
    
    //Use this for initialization
    void Start()
    {
        transform.Translate(0, 20, 0);
        StartCoroutine(Appear());
    }

    //Update is called once per frame
    void Update()
    {

    }

    IEnumerator Appear()
    {
        yield return new WaitForSeconds(WaitToAppear);
        transform.Translate(0, -20, 0);

        int PlayPopSound = GV.GetComponent<GlobalVariables>().MapLength;
        if(PlayPopSound > 0 )
        {

            FindObjectOfType<AudioManager>().Play("Pop");
        }

    }
}
