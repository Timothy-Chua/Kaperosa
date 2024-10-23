using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level5_Bathroom : MonoBehaviour
{
    public PlayableDirector director;

    private void OnTriggerEnter(Collider actor)
    {
        /*
        if (actor.gameObject.CompareTag("Player") && Level5_Manager.instance.currentObjective == Level5Objective.Bathroom)
        {
            director.Play();
            Level5_Manager.instance.currentObjective = Level5Objective.ExitDoor;
        }*/
    }
}
