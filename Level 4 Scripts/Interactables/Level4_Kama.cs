using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_Kama : Level4_Interact
{
    protected override void Interact()
    {
        base.Interact();

        if (Level4_Manager.instance.currentObjective == assignedObjective)
        {
            if (!isInteracted)
            {
                isInteracted = true;

                Level4_SoundManager.instance4.PlaySFX(0);

                Level4_Manager.instance.SetSkyDay();
                StartCoroutine(NextDialogue("collider", 2, Level4Objective.tv));
            }
        }
    }
}
