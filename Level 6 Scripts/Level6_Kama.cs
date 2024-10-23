using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level6_Kama : Level6_Interact
{
    public PlayableDirector director;

    protected override void Interact()
    {
        base.Interact();
        ClearInteract();
        StartCoroutine(Cutscene());
    }

    IEnumerator Cutscene()
    {
        director.Play();

        yield return new WaitForSeconds(9.5f);

        Level6_Manager.instance.currentObjective = Level6Objective.Bathroom;
        DeactivateCollider();
    }
}
