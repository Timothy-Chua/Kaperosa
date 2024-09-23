using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level5_Taxi : Level5_Interact
{
    public PlayableDirector director;

    protected override void Interact()
    {
        base.Interact();

        director.Play();
    }
}
