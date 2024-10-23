using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level6_BathroomTrigger : MonoBehaviour
{
    public PlayableDirector director;

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player") && Level6_Manager.instance.currentObjective == Level6Objective.Bathroom)
        {
            director.Play();
            Level6_Manager.instance.currentObjective = Level6Objective.ExitDoor;
        }
    }
}
