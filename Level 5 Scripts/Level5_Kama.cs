using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level5_Kama : Level5_Interact
{
    public PlayableDirector director;

    protected override void Interact()
    {
        base.Interact();

        StartCoroutine(Cutscene());
    }

    IEnumerator Cutscene()
    {
        director.Play();

        yield return new WaitForSeconds(9.5f);

        //Level5_Manager.instance.currentObjective = Level5Objective.Bathroom;
        DeactivateCollider();
    }
}
