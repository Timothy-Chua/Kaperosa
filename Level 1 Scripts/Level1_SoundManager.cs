using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_SoundManager : SoundManager
{
    public static Level1_SoundManager instance1;

    protected override void Awake()
    {
        base.Awake();

        if (instance1 == null)
            instance1 = this;
        else
            Destroy(this.gameObject);
    }

    protected override void Start()
    {
        Say(0);
    }
}
