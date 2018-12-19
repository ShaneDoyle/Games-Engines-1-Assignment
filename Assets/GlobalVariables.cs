using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float EnemySpeedMax;


    //Built in
    [HideInInspector]
    public bool RegenLand = false;
    [HideInInspector]
    public float EndingPlaneX;
    [HideInInspector]
    public bool PlayPopSound = true;

    public Text WaveCounter;

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
            Wave++;
            MapLength += MapLengthExpander;
            EnemySpeed += EnemySpeedIncrease;
            EnemyLimit++;
            detailScale = Random.Range(15, 25);
            heightScale = Random.Range(1, 3);
            PlayPopSound = true;

            //Ensure that speed doesn't go too high!
            if (EnemySpeed >= EnemySpeedMax)
            {
                EnemySpeed = EnemySpeedMax;
            }
        }

        WaveCounter.text = "Wave: " + Wave;

    }
}
