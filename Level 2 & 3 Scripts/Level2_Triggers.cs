using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Triggers : MonoBehaviour
{
    public Animation kjAnimation;

    public virtual void OnTriggerEnter(Collider Actor)
    {
        if(Actor.CompareTag("Player"))
        {
            kjAnimation.Play();
            Level2_SoundManager.instance.PlaySFXWithoutFade(0);
            gameObject.SetActive(false);
        }
    }
}
