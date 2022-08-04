using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class InGameMenu : MonoBehaviour {
    [SerializeField]
    TextMeshProUGUI coinHUDText;

    RocketScript rocketScript;

    [SerializeField]
    GameObject hudObject;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject gameOptions;

    [SerializeField]
    Toggle muteAudio;

    Camera gameCamera;
    AudioListener cameraAudio;

    bool audioOn = true;

    void Start()
    {
        rocketScript = FindObjectOfType<RocketScript>();

        gameCamera = FindObjectOfType<Camera>();
        cameraAudio = gameCamera.GetComponent<AudioListener>();

        //coinHUDText = FindObjectOfType<TextMeshProUGUI>();
        hudObject.SetActive(true);
        pauseMenu.SetActive(false);
        gameOptions.SetActive(false);
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

    public void ShowOptions() {
        gameOptions.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ShowPause() {
        gameOptions.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void MuteToggle() {
        Debug.Log(muteAudio.isOn);
        if (muteAudio.isOn) {
            cameraAudio.enabled = false;
        }
        else {
            cameraAudio.enabled = true;
        }
    }
}
