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
    public GameObject plane;
    public GameObject lavaplane;
    public GameObject player;

    int planeSize = 10;
    int halfTilesX = 5;
    int halfTilesZ = 5;

    Vector3 startPos;

    Hashtable tiles = new Hashtable();

	//Use this for initialization
	void Start ()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for(int x = -5; x < 5; x++)
        {
            for (int z = 1; z < 6; z++)
            {
                Vector3 pos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));
                GameObject t;
                //Make Middle
                if (z != 2 || x < 0)
                { 
                    t = (GameObject)Instantiate(lavaplane, pos, Quaternion.identity);
                }
                else
                {
                    t = (GameObject)Instantiate(lavaplane, pos, Quaternion.identity);
                    t = (GameObject)Instantiate(plane, pos, Quaternion.identity);
                }


                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
               
            }
        }
	}
	
	//Update is called once per frame
	void Update ()
    {
        //To int position.
        /*
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if(Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            int playerX = (int)(Mathf.Floor(player.transform.position.x / planeSize) * planeSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z / planeSize) * planeSize);

            for(int x = -halfTilesX * 4; x < halfTilesX * 4; x++)
            {
                for(int z = 1; z < 6; z++)
                {
                    Vector3 pos = new Vector3((x * planeSize + playerX), 0, (z * planeSize + playerZ));

                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    //If tile doesn't exist in array because it is still in "render distance".
                    if (!tiles.ContainsKey(tilename))
                    {
                        GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tilename, tile);
                    }
                    else
                    {
                        (tiles[tilename] as Tile).creationTime = updateTime;
                    }
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
    */
	}
}
