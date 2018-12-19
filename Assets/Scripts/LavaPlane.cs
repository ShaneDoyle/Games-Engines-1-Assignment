using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlane : MonoBehaviour
{
    public float WaitToAppear;

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
        FindObjectOfType<AudioManager>().Play("Pop");
        transform.Translate(0, -20, 0);
    }
}
