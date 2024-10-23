using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6_Manager : MonoBehaviour
{
    public static Level6_Manager instance;
    public Level6Objective currentObjective;

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


        currentObjective = Level6Objective.Sleep;
        isHorror = false;

        StartCoroutine(DelayStartDialogue());
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

    public void HouseKaperosaSetActive2()
    {
        kaperosaHouseObj[1].SetActive(true);
    }

    public void HouseKaperosaSetActive1()
    {
        kaperosaHouseObj[0].SetActive(false);
    }

    public void HouseKaperosaSetActive(bool activeState)
    {
        foreach (GameObject obj in kaperosaHouseObj)
        {
            obj.SetActive(activeState);
        }
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(6);
    }

    IEnumerator DelayStartDialogue()
    {
        yield return new WaitForSeconds(1.5f);

        SoundManager.instance.Say(0);
    }
}

public enum Level6Objective
{
    Sleep,
    Bathroom,
    ExitDoor,
    Taxi
}
