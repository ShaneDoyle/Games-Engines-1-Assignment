using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnowbomb : MonoBehaviour
{

    public Transform target;
    public float time = 10f;
    public float hp = 3;
    public float speed = 0.05f;
    public AudioSource deathSound;

    Vector3 toTarget;

    //Emission of HP.
    Color color = Color.green;
    Renderer rend;

    //Explosion Variables.
    private float deathSphereSize = 0.2f;
    private int spheresInRow = 3;
    private GameObject deathsphere;

    //Built in.
    private SphereCollider myCollider;
    private float x = 0;
    private bool DeathSoundPlayed = false;

    //Use this for initialization
    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
    }


    //Update is called once per frame
    void Update()
    {
        if (hp != 0)
        { 
            FindClosestPlayer();
        }

        //Rolling Stuff
        x += 8;
        if (x > 360.0f)
        {
            x = 0.0f;
        }
        transform.localRotation = Quaternion.Euler(0, x, 0);

        GetComponent<Renderer>().material.color = color;
        GetComponent<Renderer>().material.SetColor("_EmissionColor", color * (hp * 0.2f));

        //Death
        if (hp == 0)
        {
            if (DeathSoundPlayed == false)
            {
                deathSound.Play(0);
                DeathSoundPlayed = true;
            }

            if (transform.localScale.y >= 0.3F)
            {
                transform.localScale -= new Vector3(-0.05f, 0.10f, -0.05f);
                myCollider.radius -= 0.03f;
            }
        }
    }


    //Use to move to go to closest player.
    void FindClosestPlayer()
    {
        float distancetoClosestPlayer = Mathf.Infinity;
        Player closestPlayer = null;
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();

        foreach(Player currentPlayer in allPlayers)
        {
            float distancetoPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if(distancetoPlayer < distancetoClosestPlayer)
            {
                distancetoClosestPlayer = distancetoPlayer;
                closestPlayer = currentPlayer;
            }
        }


        transform.Rotate(0, 0, 0);
        transform.position = Vector3.MoveTowards(transform.position, closestPlayer.transform.position, 0.05f);
    }


    

    //When bomb dies, explode!
    void Explode()
    {
        //Instantiate(explosioneffect, transform.position, transform.rotation);
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

        }
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

    //Kill self if touching a player.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            
        }

        if (col.gameObject.tag == "Bullet")
        {
            if (hp > 0)
            {
                hp -= 1;
            }
        }

    }
}
