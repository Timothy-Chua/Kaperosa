using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_SoundManager : SoundManager
{
    private int currentDialogue = 0;

    protected override void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        currentDialogue = 0;
    }

    public void SayDialogue()
    {
        Say(currentDialogue);
        currentDialogue++;
    }
}
