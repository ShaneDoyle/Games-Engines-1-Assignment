using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextWave : MonoBehaviour {

	//Use this for initialization.
	void Start ()
    {
		
	}
	
	//Update is called once per frame.
	void Update ()
    {

    }

    //Take damage from objects.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
       {
            Destroy(gameObject);
            Debug.Log("END OF LEVEL");
        }
    }
}
