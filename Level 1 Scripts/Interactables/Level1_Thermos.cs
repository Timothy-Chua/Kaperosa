using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Thermos : Level1_Interact
{
    protected override void Interact()
    {
        // takes base scripts in Interact()
        // default = empty
        base.Interact();

        if (Level1_Manager.instance.currentObjective == Level1Objective.coffee)
        {
            isInteracted = true;

            // updates level 1 manager that thermos is collected
            Level1_Manager.instance.isThermosCollected = true;
            
            // ADD: play next dialogue from sound manager
            DeactivateCollider();
        }
    }
}
