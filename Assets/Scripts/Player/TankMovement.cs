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

    //More Built in components.
    private bool CanMove = false;
    Rigidbody RB;

    //Pause before spawning.
    void Start ()
    {
        CanMove = false;
        transform.Translate(0, 20000, 0);

        RB = GetComponent<Rigidbody>();
        RB.useGravity = false;
        StartCoroutine(Appear());
    }

    //Appear after initial delay.
    IEnumerator Appear()
    {
        yield return new WaitForSeconds(2.25f);
        FindObjectOfType<AudioManager>().Play("Pop");
        RB.useGravity = true;
        transform.position = new Vector3(0, 5, 20);
        CanMove = true;
    }

    //Update is called once per frame.
    void Update()
    {
        //If not dead, allow player to move and shoot.
        if (Death == false && CanMove == true)
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

        //Used to reset wave.
        if(transform.position.y < -50)
        {
            Destroy(gameObject);
        }

        //If death by lava.
        if(DeathLava == true)
        {
            transform.Translate(0, -0.020f, 0);
            transform.Rotate(0, 15, 0);
        }

        ///If death by enemies.
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

    //Called when touching lava.
    IEnumerator KillPlayerByLava()
    {
        DeathLava = true;
        FindObjectOfType<AudioManager>().Play("Player Death");
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    //Called when touching enemy.
    IEnumerator KillPlayerByGoo()
    {
        DeathEnemy = true;
        FindObjectOfType<AudioManager>().Play("Player Death");
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

    //Check for collisions.
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
    }
}
