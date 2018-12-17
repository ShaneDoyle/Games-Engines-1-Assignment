using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int Wave = 1;
    public int SpawnTime = 2;

    private bool StopSpawn = false;
    private static int EnemyLimit = 2;
    private float PlayerXPos;
    public GameObject enemy;



    //public Transform test = GameObject.Find("Your_Name_Here").transform.position;



    //Use this for initialization
    void Start ()
    {
        
    }

	
	//Update is called once per frame
	void Update ()
    {
        PlayerXPos = GameObject.FindGameObjectWithTag("PlayerCamera").transform.position.x;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < EnemyLimit && StopSpawn == false)
        {
            StopSpawn = true;
            float xDistance = Random.Range(20, 40);
            Instantiate(enemy, new Vector3(PlayerXPos + xDistance, 1, Random.Range(16, 22)), Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime);
            StopSpawn = false;
        }
    }
}
