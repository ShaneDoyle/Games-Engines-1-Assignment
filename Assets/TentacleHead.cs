using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleHead : MonoBehaviour
{
    public float rotateZSpeed = 5;

    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        //Flip effect
        transform.Rotate(0, 0, rotateZSpeed);
    }
}
