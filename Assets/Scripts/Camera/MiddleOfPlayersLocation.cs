using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleOfPlayersLocation : MonoBehaviour
{
    private Vector3 test;
    private float CameraLocation = 0;
    private float PreviousCameraLocation = 0;
    private int NumOfPlayers = 0;

    private float StartCamera = 0.15f;

    //Use this for initialization
    void Start()
    {
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();

        foreach (Player currentPlayer in allPlayers)
        {
            CameraLocation += currentPlayer.transform.position.x / allPlayers.Length;
            test = new Vector3(Mathf.Lerp(transform.position.x, CameraLocation, 1), 0, 0);
        }
        transform.position = test;
    }

    //Update is called once per frame
    void Update ()
    {
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();

        foreach (Player currentPlayer in allPlayers)
        {
            CameraLocation += currentPlayer.transform.position.x / allPlayers.Length ;
            test = new Vector3(Mathf.Lerp(transform.position.x,CameraLocation,StartCamera), 0, 0);
        }

        //Set camera to position and reset to re-do coordinates
        transform.position = test;
        PreviousCameraLocation = CameraLocation;
        CameraLocation = 0;
        NumOfPlayers = 0;
    }
}
