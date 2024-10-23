using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeControl : MonoBehaviour
{
    public AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        audioSource.volume = AudioManager.instance.volume;
    }

    protected virtual void FixedUpdate()
    {
        audioSource.volume = AudioManager.instance.volume;
    }
}
