using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnowbomb : MonoBehaviour
{
    //Input Variables.
    public Transform target;
    public float hp = 3;
    private float maxhp;
    public float speed = 3;
    public AudioSource deathSound;


    Vector3 toTarget;

    //Emission of HP.
    Color color = Color.green;
    Renderer rend;

    //Explosion/Death Variables.
    private float deathSphereSize = 0.2f;
    private int spheresInRow = 3;
    private GameObject deathsphere;
    private float xDown = 0.03f;
    private float yDown = 0.03f;
    private float zDown = 0.03f;

    //Built in.
    private SphereCollider myCollider;
    private float x = 0;
    private bool DeathSoundPlayed = false;
    private bool Expand = true;

    //Use this for initialization
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        maxhp = hp;
        speed *= 0.01f;

    }


    //Update is called once per frame
    void Update()
    {
        if (hp != 0)
        {
            FindClosestPlayer();
            x += 8;
        }
        else
        {
            x += 4;
        }

        //Rolling Stuff
        if (x > 360.0f)
        {
            x = 0.0f;
        }
        transform.localRotation = Quaternion.Euler(0, x, 0);

        GetComponent<Renderer>().material.color = color;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color * (hp * 0.075f));


        //Death
        if (hp == 0)
        {
            if (DeathSoundPlayed == false)
            {
                // deathSound.Play();
                FindObjectOfType<AudioManager>().Play("Goo Death");
                DeathSoundPlayed = true;
            }

            if (transform.localScale.y >= 0.3F)
            {
                transform.localScale -= new Vector3(-0.05f, 0.10f, -0.05f);
                myCollider.radius -= 0.03f;
            }

            //Start death function.
            gameObject.tag = "Untagged";
            StartCoroutine(Explode());
        }
    }


    //Use to move to go to closest player.
    void FindClosestPlayer()
    {
        float distancetoClosestPlayer = Mathf.Infinity;
        Player closestPlayer = null;
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();
        float closestPlayerX = 0;

        foreach(Player currentPlayer in allPlayers)
        {
            
            float distancetoPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if(distancetoPlayer < distancetoClosestPlayer)
            {
                distancetoClosestPlayer = distancetoPlayer;
                closestPlayerX = currentPlayer.transform.position.x;
                closestPlayer = currentPlayer;
            }
        }


        //Chase players if they exist.
        if (allPlayers.Length > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, closestPlayer.transform.position, speed);
        }

        //Let goo expand over time.
        if (Expand == true)
        {
            //Speed up goo ball over time.
            if (transform.position.x - closestPlayerX < 0)
            {
               StartCoroutine(ExpandGoo(3));
            }
        }
    }

    //If not killed, will grow and get faster. Prevents player from ignoring enemies.
    IEnumerator ExpandGoo(float waittime)
    {
        Expand = false;
        //yield return new WaitForSeconds(waittime);
        Expand = true;
        if (speed < 0.2f)
        {
            speed *= 1.01f;
        }
        yield return null;
    }

    //When bomb dies, explode!
    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1);
        transform.localScale -= new Vector3(xDown, 0, zDown);

        if(transform.localScale.x < 0)
        {
            xDown = 0;
        }
        if (transform.localScale.z < 0)
        {
            zDown = 0;
        }

        yield return new WaitForSeconds(3);
        GameObject.Destroy(this.gameObject);


        
        //Instantiate(explosioneffect, transform.position, transform.rotation);
        /*
        gameObject.SetActive(false);

        for(int x = 0; x < spheresInRow; x++)
        {
            for (int y = 0; y < spheresInRow; y++)
            {
                for (int z = 0; z < spheresInRow; z++)
                {
                    createDeathEffect(x, y, z);
                }
            }
        }*/
        
    }

    //Explode into pieces!
    void createDeathEffect(int x, int y, int z)
    {
        //Create pieces.
        deathsphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        //Set piece positions and scale.
        deathsphere.transform.position = transform.position + new Vector3(deathSphereSize * x, deathSphereSize * y, deathSphereSize * z);
        deathsphere.transform.localScale = new Vector3(deathSphereSize, deathSphereSize, deathSphereSize);

        //Add Rigidbody and mass.
        deathsphere.AddComponent<Rigidbody>();
        deathsphere.GetComponent<Rigidbody>().mass = 0.2f;
    }


    //Take damage from objects.
    void OnCollisionEnter(Collision col)
    {
        if (gameObject.tag == "Enemy")
        {
            if (col.gameObject.tag == "Player")
            {
                hp = 5;
            }

            if (col.gameObject.tag == "Bullet")
            {
                //Lose HP when hit.
                if (hp > 0)
                {
                    hp -= 1;
                }

                //Play hit sound when hit but not when death sound will play.
                if (hp >= 1)
                {
                    FindObjectOfType<AudioManager>().Play("Goo Hit");
                }
            }
        }
    }
}
