using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Toothbrush : Level1_Interact
{
    protected override void Interact()
    {
        // takes base scripts in Interact()
        // default = empty
        base.Interact();

        if (Level1_Manager.instance.currentObjective == Level1Objective.toothbrush)
        {
            isInteracted = true;

            SoundManager.instance.PlaySFX(6);

            // deactivates collider, plays next dialogue, then sets next objective
            StartCoroutine(NextDialogue("collider", 6, Level1Objective.shirt));
        }
    }
}
