using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    public int firstLevelIndex;

    public GameObject panelMain;
    public GameObject panelOptions;
    public GameObject panelAbout;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        panelMain.SetActive(true);
        panelOptions.SetActive(false);
        panelAbout.SetActive(false);

        RenderSettings.skybox.SetFloat("_Exposure", 0.5f);
    }

    public void _BtnStart()
    {
        SceneManager.LoadScene(firstLevelIndex);
    }

    public void _BtnOption()
    {
        panelMain.SetActive(false);
        panelOptions.SetActive(true);
        panelAbout.SetActive(false);
    }

    public void _BtnQuit()
    {
        Application.Quit();
    }

    public void _BtnBack()
    {
        panelMain.SetActive(true);
        panelOptions.SetActive(false);
        panelAbout.SetActive(false);
    }

    public void _BtnAbout()
    {
        panelMain.SetActive(false);
        panelOptions.SetActive(false);
        panelAbout.SetActive(true);
    }
}
