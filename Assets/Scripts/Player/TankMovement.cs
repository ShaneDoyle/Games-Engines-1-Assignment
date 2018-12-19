using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float cameraDistance = 10;
    public float rotationSpeed = 90;

    public GameObject bulletSpawnPoint;
    public GameObject bulletPrefab;

    //Built in Death Variables.
    private bool Death = false;
    private bool DeathLava = false;
    private bool DeathEnemy = false;
    private float xDown = 0.01f;
    private float yDown = 0.01f;
    private float zDown = 0.01f;

    //Use this for initialization
    void Start ()
    {
		
	}

    //Update is called once per frame
    void Update()
    {
        if (Death == false)
        { 
            transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, Space.World);
            transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0, Space.World);
            transform.Rotate(0, Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime, 0);

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
                bullet.transform.position = bulletSpawnPoint.transform.position;
                bullet.transform.rotation = transform.rotation;
            }
        }

        if(DeathLava == true)
        {
            transform.Translate(0, -0.020f, 0);
            transform.Rotate(0, 15, 0);
        }

        else if (DeathEnemy == true)
        {
            transform.localScale -= new Vector3(xDown, yDown, zDown);
            transform.Rotate(0, 20, 0);
            if (transform.localScale.x < 0)
            {
                yDown = 0;
            }
            if (transform.localScale.y < 0)
            {
                xDown = 0;
            }
            if (transform.localScale.z < 0)
            {
                zDown = 0;
            }
        }
    }

    //Called when touching lava
    IEnumerator KillPlayerByLava()
    {
        DeathLava = true;
        FindObjectOfType<AudioManager>().Play("Player Death");
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    //Called when touching enemy
    IEnumerator KillPlayerByGoo()
    {
        DeathEnemy = true;
        FindObjectOfType<AudioManager>().Play("Player Death");
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Lava")
        {
            Destroy(gameObject.GetComponent("BoxCollider"));
            Destroy(gameObject.GetComponent("Rigidbody"));
            Death = true;
            StartCoroutine(KillPlayerByLava());
        }

        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject.GetComponent("BoxCollider"));
            Destroy(gameObject.GetComponent("Rigidbody"));
            Death = true;
            StartCoroutine(KillPlayerByGoo());
        }

        if (col.gameObject.tag == "EndingPlane")
        {

            //Destroy Players.
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");
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
        }
    }

}
