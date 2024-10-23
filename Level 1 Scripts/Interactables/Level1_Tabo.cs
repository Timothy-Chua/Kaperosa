using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Tabo : Level1_Interact
{
    protected override void Interact()
    {
        // takes base scripts in Interact()
        // default = empty
        base.Interact();

        if (Level1_Manager.instance.currentObjective == Level1Objective.ligo)
        {
            isInteracted = true;

            SoundManager.instance.PlayMultipleSFX(4,5);

            // deactivates collider, plays next dialogue, then sets next objective
            StartCoroutine(NextDialogue("collider", 5, Level1Objective.toothbrush));
        }
    }
}
