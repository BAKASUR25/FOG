using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    public Material lavaMaterial;
    public Material floorMaterial;

    public void ChangeMaterialOfTile()
    {
        string tagname = gameObject.tag;
        switch(tagname)
        {
            case "Lava":
            gameObject.GetComponent<MeshRenderer>().material = lavaMaterial;
            transform.GetChild(0).gameObject.SetActive(false);
            break;
            case "Floor":
            gameObject.GetComponent<MeshRenderer>().material = floorMaterial;
            transform.GetChild(0).gameObject.SetActive(false);
            break;
            case "Diamond":
            transform.GetChild(0).gameObject.SetActive(true);
            break;
        }
    }
}
