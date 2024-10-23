using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Pandesal : Level1_Interact
{
    protected override void Interact()
    {
        // takes base scripts in Interact()
        // default = empty
        base.Interact();

        if (Level1_Manager.instance.currentObjective == Level1Objective.pandesal)
        {
            isInteracted = true;

            SoundManager.instance.PlaySFX(0);
            
            // deactivates object, plays next dialogue, then sets next objective
            StartCoroutine(NextDialogue("object", 1, Level1Objective.coffee));
        }
    }
}
