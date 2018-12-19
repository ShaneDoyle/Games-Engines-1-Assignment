using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPlane : MonoBehaviour
{
    //Variables.
    public float WaitToAppear; //Time to "pop" into game.

    //Initialisation.
    void Start()
    {
        transform.Translate(-0.1f, 20, 0);
        StartCoroutine(Appear());
        GameObject go = GameObject.Find("Global Variables");
    }

    //Reappear after certain time.
    IEnumerator Appear()
    {
        yield return new WaitForSeconds(WaitToAppear);
        FindObjectOfType<AudioManager>().Play("Pop");
        transform.Translate(0, -20, 0);
    }

    //Destroy all objects to start next wave.
    IEnumerator DestroyEverything()
    {
        GameObject go = GameObject.Find("Global Variables");
        go.GetComponent<GlobalVariables>().RegenLand = true;
        yield return null;
    }

    //Call coroutine when player reaches end of level.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyEverything());
            FindObjectOfType<AudioManager>().Play("Wave Complete");
        }
    }
}
