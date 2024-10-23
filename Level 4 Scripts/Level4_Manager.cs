using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_Manager : MonoBehaviour
{
    public static Level4_Manager instance;
    public Level4Objective currentObjective;

    public float exposureNight = 0.75f;
    public float expousureDay = 1f;

    public Material skyboxNight;
    public Material skyboxDay;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        
        currentObjective = Level4Objective.dialogue;
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetSkyNight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSkyNight()
    {
        RenderSettings.skybox.SetFloat("_Exposure", exposureNight);
        //RenderSettings.skybox = skyboxNight;
    }

    public void SetSkyDay()
    {
        RenderSettings.skybox.SetFloat("_Exposure", expousureDay);
        //RenderSettings.skybox = skyboxDay;
    }
}

public enum Level4Objective
{
    dialogue,
    sleep,
    tv,
    exit
}
