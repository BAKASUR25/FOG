using UnityEngine;

public class PlayerFloorDetection : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource hurt;
    public AudioSource collect;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Lava")
        {
        gameManager.DecreaseHealth();
        hurt.Play();
        }
        else if(other.gameObject.tag == "Diamond")
        {
        gameManager.IncreaseDiamondCollected(other.transform);
            collect.Play();
        }
    }
}
