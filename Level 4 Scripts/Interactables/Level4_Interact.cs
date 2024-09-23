using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_Interact : MonoBehaviour
{
    public GameObject[] parent;
    public Level4Objective assignedObjective;
    protected bool isInteracted = false;

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player") && Level4_Manager.instance.currentObjective == assignedObjective)
        {
            if (GameManager.instance.gameState == GameState.Gameplay)
                Level1_UIManager.instance.txtInteract.text = "Press [E] to interact";
        }
    }

    // protected virtual = editable/overridable in children scripts
    protected virtual void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player") && Input.GetKey(GameManager.instance.keyInteract) && Level4_Manager.instance.currentObjective == assignedObjective)
        {
            if (GameManager.instance.gameState == GameState.Gameplay)
                Interact();
        }
    }

    private void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player") && Level4_Manager.instance.currentObjective == assignedObjective)
        {
            if (GameManager.instance.gameState == GameState.Gameplay)
                ClearInteract();
        }
    }

    protected virtual void Interact()
    {
        // Behavior to be edited in children scripts
    }

    protected virtual void DeactivateObject()
    {
        ClearInteract();

        foreach (var obj in parent)
        {
            obj.SetActive(false);
        }

        this.gameObject.SetActive(false);
    }

    protected virtual void ClearInteract()
    {
        Level1_UIManager.instance.txtInteract.text = string.Empty;
    }

    protected virtual void DeactivateCollider()
    {
        ClearInteract();
        this.gameObject.SetActive(false);
    }

    protected virtual IEnumerator NextDialogue(string deactivation, int nextDialogue, Level4Objective nextObjective)
    {
        while (Level4_SoundManager.instance4.dialoguePlayer.isPlaying)
        {
            yield return null;
        }

        Level4_SoundManager.instance4.Say(nextDialogue);

        if (deactivation == "collider")
        {
            DeactivateCollider();
        }
        else if (deactivation == "object")
        {
            DeactivateObject();
        }

        Level4_Manager.instance.currentObjective = nextObjective;
    }
}
