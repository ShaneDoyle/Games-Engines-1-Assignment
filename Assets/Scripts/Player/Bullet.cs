using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Input variables.
    public float Speed = 20;

    //Initialisation.
    void Start()
    {
        Invoke("KillMe", 0.7f);
        FindObjectOfType<AudioManager>().Play("Player Shoot");
    }

    //Destroy self.
    void KillMe()
    {
        GameObject.Destroy(this.gameObject);
    }

    //Update components.
    void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }

    //Kill self if touching an enemy.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
             Destroy(gameObject);
        }
    }
}
