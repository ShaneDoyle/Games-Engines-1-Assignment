using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleOfPlayersLocation : MonoBehaviour
{
    private float cameraLocation = 0;

    //Use this for initialization
    void Start ()
    {
		
	}
	
	//Update is called once per frame
	void Update ()
    {
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();

        foreach (Player currentPlayer in allPlayers)
        {
            cameraLocation += currentPlayer.transform.position.x * 0.5f;
        }
        transform.position = new Vector3(cameraLocation, 12, 9);
        cameraLocation = 0;
    }
}
