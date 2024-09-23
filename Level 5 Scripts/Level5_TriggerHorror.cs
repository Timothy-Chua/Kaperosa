using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5_TriggerHorror : MonoBehaviour
{
    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Taxi") && Level5_Manager.instance.currentObjective == Level5Objective.Pickup)
        {
            Level5_Manager.instance.HorrorAmbiencePlay();

            Level5_SoundManager.instance5.PlayHorrorStinger();
        }
    }
}
