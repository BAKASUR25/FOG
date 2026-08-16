using System;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 public float duration = 30f;
 public TMP_Text timerText;
private float currentTime;
private bool isRunning;
public UImanager uiMnaager;
public RandomGrideGenerator gridGenerator;
public GameObject player;
private Vector3 firstSafeTile;
private int diamondTotalCount;
private int diamondCollected = 0;
private int playerHealth = 5;

public List<Sprite> endScreenImages = new List<Sprite>();

public GameObject startScreen;


    void Update()
    {
        if (!isRunning)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;

            UpdateTimerUI();
            
            EndGame(0);
            return;
        }

        UpdateTimerUI();
    }

    public void StartTimer()
    {
        currentTime = duration;
        isRunning = true;

        UpdateTimerUI();
    }

        private void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = "Time Left: "+Mathf.CeilToInt(currentTime).ToString();
    }
    void StartGame()
    {
        StartTimer();
        uiMnaager.ResetAllUI();
        diamondCollected = 0;
        playerHealth = 5;
        gridGenerator.GiveTilesTags();
        firstSafeTile = gridGenerator.GetFirstSafeTileData();
        player.transform.position = new Vector3(firstSafeTile.x,6f,firstSafeTile.z);
        player.GetComponent<ThirdPersonController>().enabled = true;
        diamondTotalCount = gridGenerator.GetDiamondCount();
        uiMnaager.ChangeText(diamondCollected,diamondTotalCount);
    }

    public void DecreaseHealth()
    {
        playerHealth--;
        uiMnaager.ChangeColor();
        if(playerHealth == 0)
        EndGame(0);
    }

    public void IncreaseDiamondCollected(Transform diamondPos)
    {
        diamondCollected++;
        gridGenerator.CloseDiamondBlock(diamondPos);
        uiMnaager.ChangeText(diamondCollected,diamondTotalCount);
        if(diamondCollected == diamondTotalCount)
        EndGame(1);
        
    }

    private void EndGame(int v)
    {
        startScreen.SetActive(true);
        player.GetComponent<ThirdPersonController>().enabled = false;
        startScreen.GetComponent<Image>().sprite = endScreenImages[v];
    }

    public void StartButton()
    {
        player.GetComponent<ThirdPersonController>().enabled = false;
        startScreen.SetActive(false);
        StartGame();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
