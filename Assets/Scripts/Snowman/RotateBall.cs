using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{

    int MovementSpeed = 2;
    bool MovementCheck = true;

	// Use this for initialization
	void Start ()
    {
		
	}

    IEnumerator Movement()
    {
        MovementCheck = false;
        MovementSpeed = Random.Range(-10, 10);
        yield return new WaitForSeconds(2);
        MovementCheck = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (MovementCheck == true)
        {
            StartCoroutine("Movement");
        }
        transform.Translate(0, 0, MovementSpeed * Time.deltaTime);
    }

}
