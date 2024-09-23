using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaCutscene : VideoCutsceneTrigger
{
    public GameObject passengerCar;
    public GameObject passengerOutside;

    protected override void PlayVideo()
    {
        base.PlayVideo();

        passengerCar.SetActive(false);
        passengerOutside.SetActive(true);
    }
}
