using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Level4_TV : Level4_Interact
{
    public PlayableDirector director;

    protected override void Interact()
    {
        base.Interact();

        if (Level4_Manager.instance.currentObjective == assignedObjective)
        {
            isInteracted = true;

            director.Play();

            Level4_Manager.instance.currentObjective = Level4Objective.exit;
            DeactivateCollider();
        }
    }
}
