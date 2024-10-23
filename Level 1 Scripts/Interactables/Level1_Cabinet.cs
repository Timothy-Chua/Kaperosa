using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Cabinet : Level1_Interact
{
    private bool isOpen = false;

    protected override void Interact()
    {
        // takes base scripts in Interact()
        // default = empty
        base.Interact();

        if (Level1_Manager.instance.currentObjective == Level1Objective.shirt)
        {
            if (!isOpen)
            {
                // play open animation
                Animator animator = parent[0].gameObject.GetComponent<Animator>();
                AudioSource player = parent[0].gameObject.GetComponent<AudioSource>();

                animator.SetTrigger("triggerOpen");
                player.Play();
                isOpen = true;
            }
            else
            {
                isInteracted = true;

                SoundManager.instance.PlaySFX(7);
                // sets next objective to exit
                Level1_Manager.instance.currentObjective = Level1Objective.exit;
                ClearInteract();
            }
        }
    }
}
