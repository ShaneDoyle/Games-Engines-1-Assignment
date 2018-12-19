using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    //Input.
    public float SpawnTime = 2;
    public GameObject enemy;

    //Gamemode control.
    private int Wave;
    private int EnemyLimit;
    GameObject GV;

    //Spawn management.
    private bool StopSpawn = false;
    private float PlayerXPos;


    //Use this for initialization.
    void Awake ()
    {
        GV = GameObject.Find("Global Variables");
        EnemyLimit = GV.GetComponent<GlobalVariables>().EnemyLimit;
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
        //Spawn enemies when there are less than the limit and spawner timer is ready.
        EnemyLimit = GV.GetComponent<GlobalVariables>().EnemyLimit;
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