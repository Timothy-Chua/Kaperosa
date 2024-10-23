using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_ExitDoor : Level4_DoorAnim
{
    protected override void OnTriggerEnter(Collider actor)
    {
        if (Level4_Manager.instance.currentObjective == Level4Objective.exit)
        {
            base.OnTriggerEnter(actor);
        }
    }

    protected override void OnTriggerStay(Collider actor)
    {
        if (Level4_Manager.instance.currentObjective == Level4Objective.exit)
        {
            base.OnTriggerStay(actor);
        }
    }

    protected override void OnTriggerExit(Collider actor)
    {
        if (Level4_Manager.instance.currentObjective == Level4Objective.exit)
        {
            base.OnTriggerExit(actor);
        }
    }
}
