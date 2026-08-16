using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOfHearts : MonoBehaviour
{
    private int idx = 5;
    public List<Image> hearts = new List<Image>();

    void Awake()
    {
        ResetAllhearts();
    }
    public void CloseLastHeart()
    {
        idx--;
        if(idx>=0)
        hearts[idx].color = Color.black;
    }

    public void ResetAllhearts()
    {
        idx = 5;
        foreach(var heart in hearts)
        {
            heart.color = Color.white;
        }
    }
}
