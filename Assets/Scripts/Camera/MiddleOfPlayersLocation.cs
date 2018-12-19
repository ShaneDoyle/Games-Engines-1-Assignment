using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleOfPlayersLocation : MonoBehaviour
{
    //Camera variables.
    private Vector3 CopyVec;
    private float CameraLocation = 0;
    private float PreviousCameraLocation = 0;
    private int NumOfPlayers = 0;
    private float StartCamera = 0.15f;

    //Initialisation.
    void Start()
    {
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();

        foreach (Player currentPlayer in allPlayers)
        {
            CameraLocation += currentPlayer.transform.position.x / allPlayers.Length;
            CopyVec = new Vector3(Mathf.Lerp(transform.position.x, CameraLocation, 1), 0, 0);
        }
        transform.position = CopyVec;
    }

    //Constantly calculate the middle player X position in order to track it.
    void Update ()
    {
        //Find all players.
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();
        foreach (Player currentPlayer in allPlayers)
        {
            CameraLocation += currentPlayer.transform.position.x / allPlayers.Length ;
            CopyVec = new Vector3(Mathf.Lerp(transform.position.x, CameraLocation, StartCamera), 0, 0);
        }

        //Set camera to position and reset to re-do coordinates
        transform.position = CopyVec;
        PreviousCameraLocation = CameraLocation;
        CameraLocation = 0;
        NumOfPlayers = 0;
    }
}
