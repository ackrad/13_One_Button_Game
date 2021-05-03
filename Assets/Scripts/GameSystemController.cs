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
    [SerializeField] Canvas hudCanvas;
    
    private float pauseTimeCounter =0f;

    int collectedCoins = 0;
    int collectedPowerups = 0;
    private bool isHoldingSpace = false;
    public bool isPaused = false;

    int totalCoins;
    int totalPowerups;
    int selection = 0;

    Button[] buttons;
    Button selectedButton;

    float selectTime = 0.35f;
    float selectTimer = 0f;

    bool isHolding = false;
    private Canvas currentlyActiveCanvas;

    private void Start()
    {
        totalCoins = FindObjectsOfType<CoinPickup>().Length;
        totalPowerups = FindObjectsOfType<PickupScript>().Length;

        coinText.text = (collectedCoins + "/" + totalCoins);
        powerUpText.text = (collectedPowerups + "/" + totalPowerups);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        buttons = pauseCanvas.GetComponentsInChildren<Button>();
    
    }

    private void Update()
    {
        if (!isPaused)
        {
            CheckPause();
        }

        else if (isPaused) //TODO  isHolding returns true when pause starts Bug. Gotta fix it later
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                selectTimer = 0f; 
                isHolding = true;
            }

            if (Input.GetKey(KeyCode.Space) && isHolding)
            {

                selectTimer +=  Time.unscaledDeltaTime;

            }

            if (Input.GetKeyUp(KeyCode.Space) && isHolding)
            {

                if (selectTimer < selectTime)
                {
                    


                    selectedButton.onClick.Invoke() ;
                }

                else 
                {
                    selection =(selection +1) % buttons.Length;
                    buttons[selection].Select();
                    selectedButton = buttons[selection];

                }
            }
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
    
    //TODO Refactor pause so it takes any possible canvas
    public void PauseGame()
    {

        BringInformativeCanvas(pauseCanvas);

    }


    public void UnpauseGame()
    {

        hudCanvas.gameObject.SetActive(true);
        currentlyActiveCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void BringInformativeCanvas(Canvas canvas)
    {
        hudCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        buttons = canvas.GetComponentsInChildren<Button>();
        buttons[0].Select();
        selection = 0;
        selectedButton = buttons[selection];
        currentlyActiveCanvas = canvas;


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
