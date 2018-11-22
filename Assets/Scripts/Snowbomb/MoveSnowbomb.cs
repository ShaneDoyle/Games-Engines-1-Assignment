﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnowbomb : MonoBehaviour
{

    public Transform target;
    public float time = 10f;
    public float hp = 3;
    float speed;

    Vector3 toTarget;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.0001F, 0.0001F, 0.0001F); //Increase size like snowball!
        time -= 0.001f;
        transform.position = Vector3.MoveTowards(transform.position, target.position, time * Time.deltaTime);
        transform.Rotate(0, 10, 0);

        if (hp == 0)
        {
            Explode();
        }
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