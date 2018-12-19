using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject theTile;
    public float creationTime;

    public Tile(GameObject t, float ct)
    {
        theTile = t;
        creationTime = ct;
    }
}



public class LandscapeGeneration : MonoBehaviour
{
    [Header("Map Tiles")]
    public GameObject StartingPlane;
    public GameObject Plane;
    public GameObject EndingPlane;
    public GameObject LavaPlane;
    [Header("Players")]
    public GameObject Player1;
    public GameObject Player2;

    //Built in variable.
    int planeSize = 10;
    int MapLength;
    Vector3 StartPos;
    GameObject GV;

    //Initialisation.
    public void Awake()
    {
        GV = GameObject.Find("Global Variables");
        MapLength = GV.GetComponent<GlobalVariables>().MapLength;
        GenerateLand();
    }

    //Constantly check if new land needs to be generated.
    void Update()
    {
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();
        GameObject[] endingPlane = GameObject.FindGameObjectsWithTag("EndingPlane");
        if (allPlayers.Length == 0 && endingPlane.Length == 0)
        {
            GenerateLand();
            GameObject P;
            P = Instantiate(Player1, new Vector3(0, 5, 10), Quaternion.Euler(0, 90, 0));
            P = Instantiate(Player2, new Vector3(0, 5, 16), Quaternion.Euler(0, 90, 0));
        }
    }

    //Generate land function.
    public void GenerateLand()
    {
        MapLength = GV.GetComponent<GlobalVariables>().MapLength;
        this.gameObject.transform.position = Vector3.zero;
        StartPos = Vector3.zero;

        for (int x = -5; x < MapLength + 5; x++)
        {
            for (int z = 1; z < 6; z++)
            {
                Vector3 lavapos = new Vector3((x * planeSize + StartPos.x), 0, (z * planeSize + StartPos.z));
                Vector3 planepos = new Vector3((x * planeSize + StartPos.x), 0.5f, (z * planeSize + StartPos.z));
                Vector3 startingplanepos = new Vector3((x * planeSize + StartPos.x), 0.5f, (z * planeSize + StartPos.z));
                GameObject t;
                string tilename;

                //Starting Plane.
                if (x == 0 && z == 2)
                {
                    t = (GameObject)Instantiate(LavaPlane, lavapos, Quaternion.identity);
                    tilename = "Lava Plane (" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString() + ")";
                    t.name = tilename;

                    t = (GameObject)Instantiate(StartingPlane, startingplanepos, Quaternion.identity);
                    tilename = "Starting Plane (" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString() + ")";
                    t.name = tilename;
                }
                //Ending Plane.
                else if (x == MapLength && z == 2)
                {
                    t = (GameObject)Instantiate(LavaPlane, lavapos, Quaternion.identity);
                    tilename = "Lava Plane (" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString() + ")";
                    t.name = tilename;

                    t = (GameObject)Instantiate(EndingPlane, planepos, Quaternion.identity);
                    tilename = "Ending Plane (" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString() + ")";
                    t.name = tilename;
                    planepos = new Vector3((x * planeSize + StartPos.x), 1f, (z * planeSize + StartPos.z));
                    GV.GetComponent<GlobalVariables>().EndingPlaneX = planepos.x; //Send to global variables.
                }
                //Lava Planes.
                else if (z != 2 || x < 0 || x >= MapLength)
                {
                    t = (GameObject)Instantiate(LavaPlane, lavapos, Quaternion.identity);
                    tilename = "Lava Plane (" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString() + ")";
                    t.name = tilename;
                }
                //Planes.
                else
                {
                    t = (GameObject)Instantiate(LavaPlane, lavapos, Quaternion.identity);
                    tilename = "Lava Plane (" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString() + ")";
                    t.name = tilename;

                    t = (GameObject)Instantiate(Plane, planepos, Quaternion.identity);
                    tilename = "Plane (" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString() + ")";
                    t.name = tilename;
                }
            }
        }
    }
}
