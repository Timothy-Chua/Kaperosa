using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Powder : Level1_Interact
{
    protected override void Interact()
    {
        // takes base scripts in Interact()
        // default = empty
        base.Interact();

        if (Level1_Manager.instance.currentObjective == Level1Objective.coffee)
        {
            isInteracted = true;

            // update manager that coffee powder is collected
            Level1_Manager.instance.isPowderCollected = true;
            
            DeactivateObject();
        }
    }
}
