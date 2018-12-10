using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnPlayers : MonoBehaviour
{

    public GameObject target;
    public float LerpTime = 0.2f;
    public float cameraDistance = 10f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z - cameraDistance);
        
    }
}
