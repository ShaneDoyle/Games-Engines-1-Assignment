using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int Wave = 1;

    private static int EnemyLimit = 2;
    public GameObject enemy;



    //public Transform test = GameObject.Find("Your_Name_Here").transform.position;



    //Use this for initialization
    void Start ()
    {
        Instantiate(enemy, new Vector3(20, 1, Random.Range(15, 22)), Quaternion.identity);
    }
	
	//Update is called once per frame
	void Update ()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < EnemyLimit)
        {
            SpawnEnemy();
        }
    }


    void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(GameObject.FindGameObjectWithTag("PlayerCamera").transform.position.x, 1, Random.Range(17, 22)), Quaternion.identity);
    }
}
