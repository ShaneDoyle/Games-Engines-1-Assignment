using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public GameObject lerpingTarget;
    public float LerpTime = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, lerpingTarget.transform.position, LerpTime);
        transform.LookAt(lerpingTarget.transform.parent);
    }
}
