using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject volumeSlider;
    private Slider slider;

    public float volume;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        slider = volumeSlider.GetComponent<Slider>();
        volume = PlayerPrefs.GetFloat("m_MasterVolume", .5f);
        slider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value != volume)
            VolumeChange();
    }

    private void VolumeChange()
    {
        volume = slider.value;
        PlayerPrefs.SetFloat("m_MasterVolume", volume);
    }
}
