using UnityEngine;
using TMPro;

public class ChangeDiamondText : MonoBehaviour
{
    public TMP_Text diamondText;

    public void ChangeText(int diamondsCollected,int totalDiamonds)
    {
        diamondText.text = diamondsCollected + "/"+ totalDiamonds;
    }
}
