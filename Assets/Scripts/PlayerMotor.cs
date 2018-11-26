using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    public Camera cam;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camerarotation = Vector3.zero;




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

    //Get a rotation vector.
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //Camera rotate function.
    public void RotateCamera(Vector3 _camerarotation)
    {
        camerarotation = _camerarotation;
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
        if(cam != null)
        {
            cam.transform.Rotate(camerarotation * -1);
        }
    }


}
