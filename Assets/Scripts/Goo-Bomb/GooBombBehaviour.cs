using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooBombBehaviour : MonoBehaviour
{
    //Input Variables.
    private float hp = 3;
    private float maxhp;
    private float speed;

    //Emission of HP. Makes Goo less bright as HP lowers.
    Color color = Color.green;
    Renderer rend;

    //Explosion/Death Variables.
    private float deathSphereSize = 0.2f;
    private int spheresInRow = 3;
    private GameObject deathsphere;
    private float xDown = 0.03f;
    private float yDown = 0.03f;
    private float zDown = 0.03f;

    //Built in variables.
    private SphereCollider myCollider;
    private float x = 0;
    private bool DeathSoundPlayed = false;
    private bool Expand = true;
    private float EndingPlaneX;

    //Initialisation.
    void Start()
    {
        GameObject GV = GameObject.Find("Global Variables");
        speed = GV.GetComponent<GlobalVariables>().EnemySpeed;
        hp = GV.GetComponent<GlobalVariables>().EnemyHP;
        EndingPlaneX = GV.GetComponent<GlobalVariables>().EndingPlaneX;
        myCollider = GetComponent<SphereCollider>();
        maxhp = hp;
        speed *= 0.01f;
    }

    //Make Goo-Bomb do things.
    void Update()
    {
        //Destroy if these conditions are met.
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        //Destroy if behind ending plane.
        if(transform.position.x > EndingPlaneX )
        {
            Destroy(gameObject);
        }

        //Move towards closest player and adjust spinning speed.
        if (hp != 0)
        {
            FindClosestPlayer();
            x += 8;
        }
        else
        {
            x += 4;
        }
        if (x > 360.0f)
        {
            x = 0.0f;
        }
        transform.localRotation = Quaternion.Euler(0, x, 0);

        //Change colour with HP.
        GetComponent<Renderer>().material.color = color;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color * (hp * 0.10f));

        //Death
        if (hp == 0)
        {
            if (DeathSoundPlayed == false)
            {
                FindObjectOfType<AudioManager>().Play("Goo Death");
                DeathSoundPlayed = true;
            }

            //"Squish" animation.
            if (transform.localScale.y >= 0.3F)
            {
                transform.localScale -= new Vector3(-0.05f, 0.10f, -0.05f);
                myCollider.radius -= 0.03f;
            }

            //Start death function.
            gameObject.tag = "Untagged";
            StartCoroutine(Squish());
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

    //If player is behind goo, they will speed up very fast. This prevents player from ignoring enemies.
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

    //When bomb dies, squish and fade out.
    IEnumerator Squish()
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
        
    }

    //Take damage from objects.
    void OnCollisionEnter(Collision col)
    {
        if (gameObject.tag == "Enemy")
        {
            //Die if touching lava.
            if (col.gameObject.tag == "Lava")
            {
                Destroy(gameObject);
            }
            
            //Restore HP when Goo-Bomb kills player.
            if (col.gameObject.tag == "Player")
            {
                hp = maxhp;
            }

            //Take damage from bullet.
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
