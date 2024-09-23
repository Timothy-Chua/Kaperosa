using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6_SoundManager : SoundManager
{
    public static Level6_SoundManager instance6;

    public AudioClip horrorAmbience;
    public bool isHorrorPlaying = false;
    public AudioClip horrorStinger;

    protected override void Awake()
    {
        base.Awake();

        if (instance6 == null)
            instance6 = this;
        else
            Destroy(this.gameObject);

        isHorrorPlaying = false;
    }

    protected override void Update()
    {
        base.Update();

        if (GameManager.instance.gameState == GameState.Gameplay || GameManager.instance.gameState == GameState.Transiton)
        {
            if (!isHorrorPlaying && Level6_Manager.instance.isHorror)
            {
                dialoguePlayer.clip = horrorAmbience;
                dialoguePlayer.Play();
                isHorrorPlaying = true;
            }
            else if (!Level6_Manager.instance.isHorror)
            {
                dialoguePlayer.Stop();
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
