using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomGrideGenerator : MonoBehaviour
{
    public List<GameObject> tiles = new List<GameObject>();

    public List<WeightedRandom> weightedRandomForTileSelection = new List<WeightedRandom>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GiveTilesTags();
    }

[ContextMenu("GenerateGrid")]
    private void GiveTilesTags()
    {
        ResetTiles();
        for(int i =0 ;i<tiles.Count;i++)
        {
            int value = UnityEngine.Random.Range(0,3);

            switch(value)
            {
                case 0:
                tiles[i].tag = "Lava";
                break;
                case 1:
                tiles[i].tag = "Floor";
                break;
                case 2:
                tiles[i].tag = "Diamond";
                break;
            }

            tiles[i].GetComponent<ChangeMesh>().ChangeMaterialOfTile();
        }
    }

    private void ResetTiles()
    {
        foreach(var tile in tiles)
        {
            tile.tag = "Floor";
            tile.GetComponent<ChangeMesh>().ChangeMaterialOfTile();
        }
    }

    public int Generate()
    {
        int totalWeight = 0;

        foreach (WeightedRandom item in weightedRandomForTileSelection)
        {
            totalWeight += item.weight;
        }

        if (totalWeight <= 0)
        {
            Debug.LogWarning("Total weight must be greater than 0.");
            return -1;
        }

        int randomWeight = UnityEngine.Random.Range(0, totalWeight);

        foreach (WeightedRandom item in weightedRandomForTileSelection)
        {
            if (randomWeight < item.weight)
            {
                return item.value;
            }

            randomWeight -= item.weight;
        }

        return -1;
    }
}

[System.Serializable]
public class WeightedRandom
{
    public int value;
    public int weight;
}


