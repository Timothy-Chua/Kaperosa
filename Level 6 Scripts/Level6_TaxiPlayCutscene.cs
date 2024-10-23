using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level6_TaxiPlayCutscene : Level6_Interact
{
    public PlayableDirector director;
    public AudioSource feet;

    protected override void Interact()
    {
        base.Interact();

        feet.volume = 0;
        feet.Stop();
        Level6_UIManager.instance.txtInteract.text = null;
        director.Play();
    }
}
