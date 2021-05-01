using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystemController : MonoBehaviour
{

    [SerializeField] Canvas pauseCanvas;
    [SerializeField] float pauseTimer = 3f;
    [SerializeField] Text coinText;
    [SerializeField] Text powerUpText;
    
    private float pauseTimeCounter =0f;

    int collectedCoins = 0;
    int collectedPowerups = 0;
    private bool isHoldingSpace = false;
    public bool isPaused = false;

    int totalCoins;
    int totalPowerups;




    private void Start()
    {
        totalCoins = FindObjectsOfType<CoinPickup>().Length;
        totalPowerups = FindObjectsOfType<PickupScript>().Length;

        coinText.text = (collectedCoins + "/" + totalCoins);
        powerUpText.text = (collectedPowerups + "/" + totalPowerups);

    }

    private void Update()
    {
        if (!isPaused)
        {
            CheckPause();
        }
    }

    public void UpdateText()
    {
        coinText.text = (collectedCoins + "/" + totalCoins);
        powerUpText.text = (collectedPowerups + "/" + totalPowerups);

    }

    public void IncreaseStarAmount()
    {
        collectedCoins += 1;
        UpdateText();
    }

    public void IncreaseCollectedPoweruo()
    {
        collectedPowerups += 1;
        UpdateText();
    }
    
    public void PauseGame()
    {

        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }


    public void UnpauseGame()
    {

        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }



   

    private void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {



            

            pauseTimeCounter = pauseTimer;
            isHoldingSpace = true;
        }

        if (Input.GetKey(KeyCode.Space) && isHoldingSpace)
        {
            if (pauseTimeCounter > 0)
            {

                pauseTimeCounter -= Time.deltaTime;
            }
            else {
                PauseGame();
                isHoldingSpace = false; }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingSpace = false;
       
        }

    }


    public void QuitGame()
    {

        Application.Quit();
    }
}
