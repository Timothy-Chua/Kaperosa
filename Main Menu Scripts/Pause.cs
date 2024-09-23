using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static Pause instance;
    [SerializeField] private GameObject panelPause, panelPlay, panelSetting, panelGameOver;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.gameState == GameState.Gameplay)
            {
                _BtnPause();
            }
            else if (GameManager.instance.gameState == GameState.PausedGame)
            {
                if (panelSetting.activeSelf == true)
                    _BtnPause();
                else
                {
                    _BtnPlay();
                }
            }
        }

        if (GameManager.instance.gameState == GameState.GameOver)
        {
            OnGameOver();
        }
    }

    public void _BtnPause()
    {
        GameManager.instance.gameState = GameState.PausedGame;
        Time.timeScale = 0f;
        AudioListener.pause = true;

        panelPause.SetActive(true);
        panelPlay.SetActive(false);
        panelSetting.SetActive(false);
        panelGameOver.SetActive(false);
    }

    public void _BtnSetting()
    {
        panelPause.SetActive(false);
        panelPlay.SetActive(false);
        panelSetting.SetActive(true);
        panelGameOver.SetActive(false);
    }

    public void _BtnPlay()
    {
        GameManager.instance.gameState = GameState.Gameplay;
        Time.timeScale = 1f;
        AudioListener.pause = false;

        panelPause.SetActive(false);
        panelPlay.SetActive(true);
        panelSetting.SetActive(false);
        panelGameOver.SetActive(false);
    }

    public void _BtnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void _BtnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnGameOver()
    {
        panelPause.SetActive(false);
        panelPlay.SetActive(false);
        panelSetting.SetActive(false);
        panelGameOver.SetActive(true);
    }
}
