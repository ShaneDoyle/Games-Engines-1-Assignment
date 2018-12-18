﻿using System.Collections;
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
    public GameObject startingplane;
    public GameObject plane;
    public GameObject endingplane;
    public GameObject lavaplane;
    public GameObject player;
    public GameObject enditem;

    int planeSize = 10;
    int halfTilesX = 5;
    int halfTilesZ = 5;

    int MapLength;

    Vector3 startPos;

    Hashtable tiles = new Hashtable();


    void Awake()
    {
        GameObject go = GameObject.Find("Global Variables");
        MapLength = go.GetComponent<GlobalVariables>().MapLength;
    }

    //Use this for initialization
    void Start ()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for(int x = -5; x < MapLength + 5; x++)
        {
            for (int z = 1; z < 6; z++)
            {
                Vector3 lavapos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));
                Vector3 planepos = new Vector3((x * planeSize + startPos.x), 0.5f, (z * planeSize + startPos.z));
                Vector3 startingplanepos = new Vector3((x * planeSize + startPos.x), 0.5f, (z * planeSize + startPos.z));
                GameObject t;

                //Starting Plane.
                if (x == 0 && z == 2)
                {
                    t = (GameObject)Instantiate(lavaplane, lavapos, Quaternion.identity);
                    t = (GameObject)Instantiate(startingplane, startingplanepos, Quaternion.identity);
                }
                //Ending Plane.
                else if (x == MapLength && z == 2)
                {
                    t = (GameObject)Instantiate(lavaplane, lavapos, Quaternion.identity);
                    t = (GameObject)Instantiate(endingplane, planepos, Quaternion.identity);
                    planepos = new Vector3((x * planeSize + startPos.x), 1f, (z * planeSize + startPos.z));
                    t = (GameObject)Instantiate(enditem, planepos, Quaternion.identity);
                }
                //Lava Planes.
                else if (z != 2 || x < 0 || x >= MapLength)
                { 
                    t = (GameObject)Instantiate(lavaplane, lavapos, Quaternion.identity);
                }
                //Planes.
                else
                {
                    t = (GameObject)Instantiate(lavaplane, lavapos, Quaternion.identity);
                    t = (GameObject)Instantiate(plane, planepos, Quaternion.identity);
                }


                string tilename = "Tile_" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
               
            }
        }
	}

    //Update is called once per frame
    /*
    void Update()
    {
        //To int position.
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if (Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            int playerX = (int)(Mathf.Floor(player.transform.position.x / planeSize) * planeSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z / planeSize) * planeSize);

            for (int x = -5; x < MapLength + 5; x++)
            {
                for (int z = 1; z < 6; z++)
                {
                    Vector3 lavapos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));
                    Vector3 planepos = new Vector3((x * planeSize + startPos.x), 0.5f, (z * planeSize + startPos.z));
                    Vector3 startingplanepos = new Vector3((x * planeSize + startPos.x), 0.5f, (z * planeSize + startPos.z));
                    GameObject t;

                    //Starting Plane.
                    if (x == 0 && z == 2)
                    {
                        t = (GameObject)Instantiate(lavaplane, lavapos, Quaternion.identity);
                        t = (GameObject)Instantiate(startingplane, startingplanepos, Quaternion.identity);
                    }
                    //Ending Plane.
                    else if (x == MapLength && z == 2)
                    {
                        t = (GameObject)Instantiate(lavaplane, lavapos, Quaternion.identity);
                        t = (GameObject)Instantiate(endingplane, planepos, Quaternion.identity);
                        planepos = new Vector3((x * planeSize + startPos.x), 1f, (z * planeSize + startPos.z));
                        t = (GameObject)Instantiate(enditem, planepos, Quaternion.identity);
                    }
                    //Lava Planes.
                    else if (z != 2 || x < 0 || x >= MapLength)
                    {
                        t = (GameObject)Instantiate(lavaplane, lavapos, Quaternion.identity);
                    }
                    //Planes.
                    else
                    {
                        t = (GameObject)Instantiate(lavaplane, lavapos, Quaternion.identity);
                        t = (GameObject)Instantiate(plane, planepos, Quaternion.identity);
                    }


                    string tilename = "Tile_" + ((int)(planepos.x)).ToString() + "_" + ((int)(planepos.z)).ToString();
                    t.name = tilename;
                    Tile tile = new Tile(t, updateTime);
                    tiles.Add(tilename, tile);

                }
            }

                Hashtable newTerrain = new Hashtable();
            foreach (Tile tls in tiles.Values)
            {
                if (tls.creationTime != updateTime)
                {
                    Destroy(tls.theTile);
                }
                else
                {
                    newTerrain.Add(tls.theTile.name, tls);
                }
            }

            tiles = newTerrain;

            startPos = player.transform.position;

        }
    }
    */
}
