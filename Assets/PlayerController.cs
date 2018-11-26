using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{




    public float speed = 5f;
    private PlayerMotor motor;

	// Use this for initialization
	void Start ()
    {
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove; //1,0,0
        Vector3 moveVertical = transform.forward * zMove; //0,0,1

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        //Apply movement!
        motor.Move(velocity);
	}
}
