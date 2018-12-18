using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float gravity = 0f;
    // Use this for initialization
    void Start()
    {
        Invoke("KillMe", 1);
        gravity *= gravity;
        FindObjectOfType<AudioManager>().Play("Player Shoot");
    }

    void KillMe()
    {
        GameObject.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        gravity += 0.001f;
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    //Kill self if touching a player.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //HitSound.Play();
             Destroy(gameObject);
        }
    }
}
