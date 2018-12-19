using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPlane : MonoBehaviour
{
    public float WaitToAppear;

    //Use this for initialization
    void Start()
    {
        transform.Translate(-0.1f, 20, 0);
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

    //If not killed, will grow and get faster. Prevents player from ignoring enemies.
    IEnumerator RespawnLand()
    {
        FindObjectOfType<LandscapeGeneration>().Awake();
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator DestroyEverything()
    {
        FindObjectOfType<LandscapeGeneration>().Awake();

        //Destroy Players.
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

        //Destroy Enemies.
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

        //Destroy Lava.
        gameObjects = GameObject.FindGameObjectsWithTag("Lava");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

        //Destroy Plane.
        gameObjects = GameObject.FindGameObjectsWithTag("Ground");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

        //Destroy Starting Plane.
        gameObjects = GameObject.FindGameObjectsWithTag("EndingPlane");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

        GameObject go = GameObject.Find("Global Variables");
        go.GetComponent<GlobalVariables>().MapLength += go.GetComponent<GlobalVariables>().MapLengthExpander;
        go.GetComponent<GlobalVariables>().EnemyLimit++;
        go.GetComponent<GlobalVariables>().detailScale = Random.Range(5, 15);
        go.GetComponent<GlobalVariables>().heightScale = Random.Range(2, 5);

        yield return null;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyEverything());
        }
    }
}
