using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;

    private Rigidbody rb;





    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Get movement vector.
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //Get a rotation vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }


    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Move the rigidbody with the velocity vector.
    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    //Perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
    }


}
