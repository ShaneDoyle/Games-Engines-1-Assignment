using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnowbomb : MonoBehaviour
{

    public Transform target;
    public float time = 8;
    float speed;

    Vector3 toTarget;

    // Use this for initialization
    void Start()
    {
        toTarget = target.transform.position - transform.position;

        float dist = toTarget.magnitude;
        speed = dist / time;

        toTarget.Normalize();


        float a1 = Mathf.Acos(Vector3.Dot(transform.forward, toTarget));
        Debug.Log(Mathf.Rad2Deg * a1);

        float a2 = Vector3.Angle(transform.forward, toTarget);

        Debug.Log(a2);


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target.position , speed * Time.deltaTime);
        //transform.LookAt(target);
        transform.Rotate(0,5,0);



        //transform.position += toTarget * speed * Time.deltaTime;

        // transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);


    }
}
