﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnowbomb : MonoBehaviour
{

    public Transform target;
    public float time = 10f;
    public float hp = 3;
    public float x = 0;
    float speed;

    Vector3 toTarget;

    // Use this for initialization
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        // transform.localScale += new Vector3(0.0005F, 0.0005F, 0.0005F); //Increase size like snowball!
        //time -= 0.001f;
        //transform.position = Vector3.MoveTowards(transform.position, target.position, time * Time.deltaTime);
        //transform.Rotate(0, 10, 0);

        FindClosestPlayer();

        x += 8;

        if (x > 360.0f)
        {
            x = 0.0f;
        }

        transform.localRotation = Quaternion.Euler(0, x, 0);


        if (hp == 0)
        {
            Explode();
        }
    }

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
        Destroy(gameObject);
    }

    //Kill self if touching a player.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            hp = 0;
        }

    }
}
