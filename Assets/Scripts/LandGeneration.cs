using UnityEngine;

public class LandGeneration : MonoBehaviour
{
    //This will define how big we want our land to be.
    public int depth = 20;
    public int width = 256;
    public int height = 256;

    //Varaibles that will affect how the land is generated.
    public float scale;

    //Movement
    public float offsetX = 100f;
    public float offsetY = 100f;

	// Use this for initialization
	void Start ()
    {
        offsetX = 1f;
        offsetY = 1f;
	}

    private void Update()
    {
        //Change the terrain properities.
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        offsetX += Time.deltaTime * 1f;
    }


    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);

    }
}
