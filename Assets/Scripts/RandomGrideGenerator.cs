using System.Collections.Generic;
using UnityEngine;

public class RandomGrideGenerator : MonoBehaviour
{
    public List<GameObject> tiles = new List<GameObject>();

    public List<WeightedRandom> weightedRandomForTileSelection = new List<WeightedRandom>();

    private bool isFirstSafeTile = false;
    private Transform firstSafeTile;
    private int diamondCount = 0;

[ContextMenu("GenerateGrid")]
    public void GiveTilesTags()
    {
        ResetTiles();
        for(int i =0 ;i<tiles.Count;i++)
        {
            int value = GenerateValue();

            switch(value)
            {
                case 0:
                tiles[i].tag = "Lava";
                break;
                case 1:
                if(!isFirstSafeTile)
                    firstSafeTile = tiles[i].transform;
                tiles[i].tag = "Floor";
                break;
                case 2:
                tiles[i].tag = "Diamond";
                diamondCount++;
                break;
            }

            tiles[i].GetComponent<ChangeMesh>().ChangeMaterialOfTile();
        }
    }

    private void ResetTiles()
    {
        diamondCount = 0;
        foreach(var tile in tiles)
        {
            tile.tag = "Floor";
            tile.GetComponent<ChangeMesh>().ChangeMaterialOfTile();
        }
    }

    private int GenerateValue()
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

    public Vector3 GetFirstSafeTileData()
    {
        return firstSafeTile.position;
    }

    public int GetDiamondCount()
    {
        return diamondCount;
    }

    public void CloseDiamondBlock(Transform diamondPos)
    {
        foreach(var tile in tiles)
        {
            if(tile.transform == diamondPos)
            {
                tile.tag = "Floor";
                tile.transform.GetChild(0).gameObject.SetActive(false);
                break;
            }
        }
    }
}

[System.Serializable]
public class WeightedRandom
{
    public int value;
    public int weight;
}


