using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public static GameManager instance;
    public GameObject GameOverPanel;

    public bool playerAlive;

    public LevelState levelState;
    public GameState gameState;

    public KeyCode keyInteract = KeyCode.E;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        playerAlive = true;

        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            levelState = LevelState.MainMenu;
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            levelState = LevelState.Level1;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            levelState = LevelState.Level2;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            levelState = LevelState.Level3;
        }
        else if (SceneManager.GetActiveScene().name == "Level 4")
        {
            levelState = LevelState.Level4;
        }
        else if (SceneManager.GetActiveScene().name == "Level 5")
        {
            levelState = LevelState.Level5;
        }
    }

    public void Update()
    {
        // Game over function in Pause script

        if (gameState == GameState.PausedGame || gameState == GameState.Interaction || gameState == GameState.GameOver)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void StateTransition()
    {
        gameState = GameState.Transiton;
    }

    public void StateGameplay()
    {
        gameState = GameState.Gameplay;
        Pause.instance._BtnPlay();
    }

    public void StatePaused()
    {
        gameState = GameState.PausedGame;
        Pause.instance._BtnPause();
    }
}

public enum LevelState
{
    MainMenu,
    Level1,
    Level2,
    Level3,
    Level4,
    Level5,
}

public enum GameState
{
    Gameplay,
    PausedGame,
    Transiton,
    Interaction,
    GameOver
}
