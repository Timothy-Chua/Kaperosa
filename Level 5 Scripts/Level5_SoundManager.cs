using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5_SoundManager : SoundManager
{
    public static Level5_SoundManager instance5;

    public AudioClip horrorAmbience;
    public bool isHorrorPlaying = false;
    public AudioClip horrorStinger;

    protected override void Awake()
    {
        base.Awake();

        if (instance5 == null)
            instance5 = this;
        else
            Destroy(this.gameObject);

        isHorrorPlaying = false;
    }

    protected override void Update()
    {
        base.Update();

        if (GameManager.instance.gameState == GameState.Gameplay || GameManager.instance.gameState == GameState.Transiton)
        {
            if (!isHorrorPlaying && Level5_Manager.instance.isHorror)
            {
                dialoguePlayer.clip = horrorAmbience;
                dialoguePlayer.loop = true;
                dialoguePlayer.Play();
                isHorrorPlaying = true;
            }
            else if (!Level5_Manager.instance.isHorror)
            {
                dialoguePlayer.Stop();
                dialoguePlayer.loop = false;
                isHorrorPlaying = false;
            }
        }
        else
        {
            isHorrorPlaying = false;
            dialoguePlayer.Stop();
        }
    }

    public virtual void PlayHorrorStinger()
    {
        dialoguePlayer.PlayOneShot(horrorStinger, AudioManager.instance.volume);
    }
}
