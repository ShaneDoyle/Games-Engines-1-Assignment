using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{

    public GameObject obj = GameObject.Find("Snowbomb");

    // Use this for initialization
    void Start ()
    {
		
	}


    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(0, 0, 3);
        obj.transform.Rotate(0, 0, 3);
    }

}
