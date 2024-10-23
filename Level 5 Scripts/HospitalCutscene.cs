using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalCutscene : VideoCutsceneTrigger
{
    public GameObject kaperosaInside;

    protected override void PlayVideo()
    {
        base.PlayVideo();

        kaperosaInside.SetActive(false);

        Level5_Manager.instance.SetObjectiveHome();
        Level5_Manager.instance.isHorror = false;
    }
}
