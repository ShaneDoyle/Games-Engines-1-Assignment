using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public float SpawnTime = 2;
    
    private bool StopSpawn = false;
    private float PlayerXPos;
    public GameObject enemy;


    //Gamemode Control
    private int Wave;
    private int EnemyLimit;
    //public Transform test = GameObject.Find("Your_Name_Here").transform.position;

    GameObject go;


    //Use this for initialization.
    void Awake ()
    {
        go = GameObject.Find("Global Variables");
        EnemyLimit = go.GetComponent<GlobalVariables>().EnemyLimit;
    }

	
	//Update is called once per frame.
	void Update ()
    {
        PlayerXPos = GameObject.FindGameObjectWithTag("PlayerCamera").transform.position.x;
        StartCoroutine(SpawnEnemy());
    }

    //Spawn enemy.
    IEnumerator SpawnEnemy()
    {
        EnemyLimit = go.GetComponent<GlobalVariables>().EnemyLimit;

        if (GameObject.FindGameObjectsWithTag("Enemy").Length < EnemyLimit && StopSpawn == false)
        {
            StopSpawn = true;
            float xDistance = Random.Range(20, 30);
            Instantiate(enemy, new Vector3(PlayerXPos + xDistance, 5, Random.Range(16, 22)), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(SpawnTime * 0.5f,SpawnTime) );
            StopSpawn = false;
        }
    }
}