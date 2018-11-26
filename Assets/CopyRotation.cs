using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    public GameObject obj;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.rotation.x = obj.transform.rotation;
       // transform.rotation = Quaternion.Euler(0, obj.transform.rotation, 0);
    }
}
