using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level1_Manager : MonoBehaviour
{
    public static Level1_Manager instance;
    public Level1Objective currentObjective;                // tracks current objective

    public bool isPowderCollected;
    public bool isThermosCollected;

    public void Awake()
    {
        if(instance == null)
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
        currentObjective = Level1Objective.pandesal;
        //SetSkyDay();
    }

    public void SetSkyNight()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 0.75f);
    }

    public void SetSkyDay()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 1f);
    }
}

public enum Level1Objective
{
    pandesal,
    coffee,
    ligo,
    toothbrush,
    shirt,
    exit
}