using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Triggers : MonoBehaviour
{
    public Animation hangerAnimation;

    public virtual void OnTriggerEnter(Collider Actor)
    {
        if(Actor.CompareTag("Player"))
        {
            hangerAnimation.Play();
            Level1_SoundManager.instance.PlaySFXWithoutFade(8);
            gameObject.SetActive(false);
        }
    }
}
