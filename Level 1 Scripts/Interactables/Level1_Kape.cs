using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Kape : Level1_Interact
{
    protected override void Interact()
    {
        // takes base scripts in Interact()
        // default = empty
        base.Interact();

        if (Level1_Manager.instance.currentObjective == Level1Objective.coffee)
        {
            if (Level1_Manager.instance.isThermosCollected && Level1_Manager.instance.isPowderCollected)
            {
                isInteracted = true;
                // ADD: play next dialogue from sound manager
                SoundManager.instance.PlayMultipleSFX(1, 3);
                // deactivates collider, plays next dialogue, then sets next objective
                StartCoroutine(NextDialogue("collider", 4, Level1Objective.ligo));
            }
            else if (!Level1_Manager.instance.isThermosCollected && Level1_Manager.instance.isPowderCollected)
            {
                // "I need to get some water" dialogue
                SoundManager.instance.Say(3);
            }
            else if (Level1_Manager.instance.isThermosCollected && !Level1_Manager.instance.isPowderCollected)
            {
                // "I need to get the coffee powder" dialogue
                SoundManager.instance.Say(2);
            }
            else
            {
                // "I need the ingredients for the coffee" dialogue
                SoundManager.instance.Say(1);
            }
        }
    }
}
