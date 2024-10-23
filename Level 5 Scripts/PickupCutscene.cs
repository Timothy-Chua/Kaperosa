using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCutscene : VideoCutsceneTrigger
{
    public GameObject girlOutside;
    public GameObject kaperosaInside;

    protected override void PlayVideo()
    {
        base.PlayVideo();

        girlOutside.SetActive(false);
        kaperosaInside.SetActive(true);

        Level5_Manager.instance.SetObjectiveHospital();
        Level5_Manager.instance.isHorror = false;
    }
}
