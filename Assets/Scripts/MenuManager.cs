using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{

    [SerializeField] Canvas menuCanvas;
    float selectTime = 0.35f;
    float selectTimer = 0f;
    int selection = 0;
    Button[] buttons;
    Button selectedButton;

    bool isHolding = false;
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);

    }    


    public void LoadSettingsMenu()
    {

        SceneManager.LoadScene(2);
    }


    public void QuitGame()
    {

        Application.Quit();
    }

    private void Start()
    {

        buttons = menuCanvas.GetComponentsInChildren<Button>();
        buttons[0].Select();
        selection = 0;
        selectedButton = buttons[selection];
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            selectTimer = 0f;
            isHolding = true;
        }

        if (Input.GetKey(KeyCode.Space) && isHolding)
        {

            selectTimer += Time.unscaledDeltaTime;

        }

        if (Input.GetKeyUp(KeyCode.Space) && isHolding)
        {

            if (selectTimer < selectTime)
            {



                selectedButton.onClick.Invoke();
            }

            else
            {
                selection = (selection + 1) % buttons.Length;
                buttons[selection].Select();
                selectedButton = buttons[selection];

            }
        }
    }
}
