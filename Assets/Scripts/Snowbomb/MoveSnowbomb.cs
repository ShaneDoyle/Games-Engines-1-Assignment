using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnowbomb : MonoBehaviour
{

    public Transform target;
    public GameObject explosioneffect;
    public float time = 10f;
    public float hp = 3;
    float speed;

    Vector3 toTarget;

    // Use this for initialization
    void Start()
    {
        /*
        toTarget = target.transform.position - transform.position;

        float dist = toTarget.magnitude;
        speed = dist / time;

        toTarget.Normalize();


        float a1 = Mathf.Acos(Vector3.Dot(transform.forward, toTarget));
        float a2 = Vector3.Angle(transform.forward, toTarget);
        */


    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.001F, 0.001F, 0.001F); //Increase size like snowball!
        time -= 0.001f;
        transform.position = Vector3.MoveTowards(transform.position, target.position, time * Time.deltaTime);
        //transform.LookAt(target);
        transform.Rotate(0, 10, 0);

        if (hp == 0)
        {
            hp = -1;
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
