using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2_Manager : MonoBehaviour
{
    public static Level2_Manager instance;

    public float exposureNight = 0.75f;
    public float expousureDay = 1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetSkyDay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSkyNight()
    {
        RenderSettings.skybox.SetFloat("_Exposure", exposureNight);
    }

    public void SetSkyDay()
    {
        RenderSettings.skybox.SetFloat("_Exposure", expousureDay);
    }
}
