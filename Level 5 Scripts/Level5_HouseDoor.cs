using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class Level5_HouseDoor : Level5_DoorAnim
{
    public PlayableDirector directorDoor;
    public Level5Objective[] assignedObjectives;

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
        /*
        if (Level5_Manager.instance.currentObjective == Level5Objective.Home)
        {
            Level5_Manager.instance.currentObjective = Level5Objective.Sleep;
            SoundManager.instance.Say(0);
            base.Interact();
        }
        else if (Level5_Manager.instance.currentObjective == Level5Objective.ExitDoor)
        {
            StartCoroutine(DoorCutscene());
        }
        else if (Level5_Manager.instance.currentObjective == Level5Objective.Taxi)
        {
            ToggleDoor();
        }
        */
    }

    protected virtual bool isAssignedObjective()
    {
        foreach (Level5Objective obj in assignedObjectives)
        {
            if (obj == Level5_Manager.instance.currentObjective)
                return true;
        }
        return false;
    }

    IEnumerator DoorCutscene()
    {
        directorDoor.Play();

        yield return new WaitForSeconds(2f);

        //Level5_Manager.instance.currentObjective = Level5Objective.Taxi;
    }
}
