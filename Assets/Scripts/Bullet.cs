using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public float gravity = 0f;
    // Use this for initialization
    void Start()
    {
        Invoke("KillMe", 5);
        gravity *= gravity;
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
            Destroy(gameObject);
        }
    }
}
