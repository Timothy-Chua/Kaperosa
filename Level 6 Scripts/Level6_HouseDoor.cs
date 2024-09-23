using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level6_HouseDoor : Level6_Door
{
    public PlayableDirector directorDoor;
    public Level6Objective[] assignedObjectives;

    protected override void OnTriggerEnter(Collider actor)
    {
        if (isAssignedObjective())
        {
            base.OnTriggerEnter(actor);
        }
    }

    protected override void OnTriggerStay(Collider actor)
    {
        if (isAssignedObjective())
        {
            base.OnTriggerStay(actor);
        }
    }

    protected override void OnTriggerExit(Collider actor)
    {
        if (isAssignedObjective())
        {
            base.OnTriggerExit(actor);
        }
    }

    protected override void Interact()
    {
        if (Level6_Manager.instance.currentObjective == Level6Objective.ExitDoor)
        {
            Level1_UIManager.instance.txtInteract.text = string.Empty;
            StartCoroutine(DoorCutscene());
        }
        else if (Level6_Manager.instance.currentObjective == Level6Objective.Taxi)
        {
            ToggleDoor();
        }
    }

    protected virtual bool isAssignedObjective()
    {
        foreach (Level6Objective obj in assignedObjectives)
        {
            if (obj == Level6_Manager.instance.currentObjective)
                return true;
        }
        return false;
    }

    IEnumerator DoorCutscene()
    {
        directorDoor.Play();

        yield return new WaitForSeconds(2f);

        Level6_Manager.instance.currentObjective = Level6Objective.Taxi;
    }
}
