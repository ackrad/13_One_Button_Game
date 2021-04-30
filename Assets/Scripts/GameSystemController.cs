using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystemController : MonoBehaviour
{

    [SerializeField] Canvas pauseCanvas;
    [SerializeField] float pauseTimer = 3f;
    private float pauseTimeCounter =0f;

    int collectedStars = 0;
    private bool isHoldingSpace = false;

    public void IncreaseStarAmount()
    {
        collectedStars += 1;

    }

    
    public void PauseGame()
    {

        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;

    }


    public void UnpauseGame()
    {

        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;

    }



    private void Update()
    {
        CheckPause();
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
