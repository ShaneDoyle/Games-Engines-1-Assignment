using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalVariables : MonoBehaviour
{
    //Global Variables

    //Gamemode stuff.
    public int Wave;

    //Land Stuff
    public int MapLength = 10;
    public int MapLengthExpander = 1;
    public int heightScale = 5;
    public float detailScale = 1f;

    //Enemy Stuff
    public int EnemyLimit;
    public float EnemySpeed;
    public float EnemySpeedIncrease;


    //Built in
    [HideInInspector]
    public bool RegenLand = false;

    //Don't apply additions on first wave.
    void Start()
    {
        Wave--;
        MapLength--;
        EnemyLimit--;
        EnemySpeed -= EnemySpeedIncrease;
    }

    //Check if game needs to regen land.
    void Update()
    {
        if(RegenLand == true)
        {
            GameObject go = GameObject.Find("Global Variables");
            go.GetComponent<GlobalVariables>().RegenLand = false;

            //Regen land function.
            FindObjectOfType<LandscapeGeneration>().Awake();

            //Destroy Players.
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
            for (var i = 0; i < gameObjects.Length; i++)
            {
                // Destroy(gameObjects[i]);
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

            //Increase next wave!
            go.GetComponent<GlobalVariables>().Wave++;
            go.GetComponent<GlobalVariables>().MapLength += go.GetComponent<GlobalVariables>().MapLengthExpander;
            go.GetComponent<GlobalVariables>().EnemySpeed += EnemySpeedIncrease;
            go.GetComponent<GlobalVariables>().EnemyLimit++;
            go.GetComponent<GlobalVariables>().detailScale = Random.Range(10, 25);
            go.GetComponent<GlobalVariables>().heightScale = Random.Range(2, 4);
        }
    }
}
