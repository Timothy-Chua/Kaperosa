using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Level4_SoundManager : SoundManager
{
    public static Level4_SoundManager instance4;

    public AudioSource cameraCouch;
    public AudioSource tvSource;

    protected override void Awake()
    {
        base.Awake();

        if (instance4 == null)
            instance4 = this;
        else
            Destroy(this.gameObject);
    }

    protected override void Start()
    {
        base.Start();

        StartCoroutine(StartDialogue());
    }

    protected override void Update()
    {
        base.Update();

        tvSource.volume = AudioManager.instance.volume;
        cameraCouch.volume = AudioManager.instance.volume;
    }

    protected virtual IEnumerator StartDialogue()
    {
        PlayMultipleDialogue(0, 1);

        while (dialoguePlayer.isPlaying)
        {
            yield return null;
        }

        Level4_Manager.instance.currentObjective = Level4Objective.sleep;
    }
}
