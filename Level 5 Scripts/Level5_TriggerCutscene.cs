using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level5_TriggerCutscene : MonoBehaviour
{
    public PlayableDirector director;

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Taxi"))
        {
            director.Play();
            this.gameObject.SetActive(false);
        }
    }
}
