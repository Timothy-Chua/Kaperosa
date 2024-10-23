using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level5_Manager : MonoBehaviour
{
    public static Level5_Manager instance;
    public Level5Objective currentObjective;

    public bool isHorror;

    public float exposureNight = 0.75f;
    public float expousureDay = 1f;

    public Material skyboxNight;
    public Material skyboxDay;

    public GameObject[] kaperosaHouseObj;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);


        currentObjective = Level5Objective.Pickup;
        isHorror = false;
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

    public void HorrorAmbiencePlay()
    {
        isHorror = true;
    }

    public void HorrorAmbienceStop()
    {
        isHorror = false;
    }

    public void SetObjectiveHospital()
    {
        currentObjective = Level5Objective.Hospital;
    }

    public void SetObjectiveHome()
    {
        currentObjective = Level5Objective.Home;
    }

    public void LoadEndScene()
    {
        // fix to load next scene
        SceneManager.LoadScene(5);
    }
}

public enum Level5Objective
{
    Pickup,
    Hospital,
    Home
}
