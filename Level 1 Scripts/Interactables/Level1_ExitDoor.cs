using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_ExitDoor : Level1_Door_Anim
{
    protected override void OnTriggerEnter(Collider actor)
    {
        if (Level1_Manager.instance.currentObjective == Level1Objective.exit)
        {
            base.OnTriggerEnter(actor);
        }
    }

    protected override void OnTriggerStay(Collider actor)
    {
        if (Level1_Manager.instance.currentObjective == Level1Objective.exit)
        {
            base.OnTriggerStay(actor);
        }
    }

    protected override void OnTriggerExit(Collider actor)
    {
        if (Level1_Manager.instance.currentObjective == Level1Objective.exit)
        {
            base.OnTriggerExit(actor);
        }
    }
}
