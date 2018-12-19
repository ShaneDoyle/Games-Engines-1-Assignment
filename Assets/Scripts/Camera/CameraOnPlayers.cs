using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnPlayers : MonoBehaviour
{
    //Input variables.
    public GameObject target;
    public float LerpTime = 0.2f;

    //Follow average X coordinates of players.
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
    }
}
