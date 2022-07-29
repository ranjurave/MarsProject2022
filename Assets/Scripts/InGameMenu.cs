using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class InGameMenu : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI coinHUDText;

    RocketScript rocketScript;

    [SerializeField]
    GameObject hudObject;

    [SerializeField]
    GameObject pauseMenu;

    void Start()
    {
        rocketScript = FindObjectOfType<RocketScript>();
        //coinHUDText = FindObjectOfType<TextMeshProUGUI>();
        hudObject.SetActive(true);
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            hudObject.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            rocketScript.gamePaused = true;
        }
        coinHUDText.text = "Coins Collected : " + rocketScript.CoinsCollected.ToString();
    }

    public void ResumeGame()
    {
        hudObject.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        rocketScript.gamePaused = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Debug.Log("Application Quitting");
        Application.Quit();
    }
}
