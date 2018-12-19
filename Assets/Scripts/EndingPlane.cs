using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPlane : MonoBehaviour
{
    public float WaitToAppear;
    bool isActive;

    //Use this for initialization
    void Start()
    {
        transform.Translate(-0.1f, 20, 0);
        StartCoroutine(Appear());

        GameObject go = GameObject.Find("Global Variables");
        isActive = go.GetComponent<GlobalVariables>().RegenLand;
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

    //If not killed, will grow and get faster. Prevents player from ignoring enemies.
    IEnumerator RespawnLand()
    {
        FindObjectOfType<LandscapeGeneration>().Awake();
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator DestroyEverything()
    {
        GameObject go = GameObject.Find("Global Variables");
        go.GetComponent<GlobalVariables>().RegenLand = true;
        yield return null;

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyEverything());
            FindObjectOfType<AudioManager>().Play("Wave Complete");
        }
    }
}
