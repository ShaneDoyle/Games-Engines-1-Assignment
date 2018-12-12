﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float cameraDistance = 10;
    public float rotationSpeed = 90;

    //Use this for initialization
    void Start ()
    {
		
	}
	
	//Update is called once per frame
	void Update ()
    {
        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0, Space.World);
        transform.Rotate(0, Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime, 0);
    }
}