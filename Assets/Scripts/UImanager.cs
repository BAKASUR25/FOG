using UnityEngine;

public class UImanager : MonoBehaviour
{
    public ChangeColorOfHearts changerColor;
    public ChangeDiamondText changedText;


    public void ChangeColor()
    {
        changerColor.CloseLastHeart();
    }

    public void ChangeText(int diamondsCollected,int totaldiamonds)
    {
        changedText.ChangeText(diamondsCollected,totaldiamonds);
    }

    public void ResetAllUI()
    {
        changerColor.ResetAllhearts();
    }
}
