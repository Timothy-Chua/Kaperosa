using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5_Interact : MonoBehaviour
{
    public GameObject[] parent;
    public Level5Objective assignedObjective;
    protected bool isInteracted = false;

    protected virtual void Awake()
    {
        isInteracted = false;
    }

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player") && Level5_Manager.instance.currentObjective == assignedObjective)
        {
            if (GameManager.instance.gameState == GameState.Gameplay)
                Level1_UIManager.instance.txtInteract.text = "Press [E] to interact";
        }
    }

    // protected virtual = editable/overridable in children scripts
    protected virtual void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player") && Input.GetKey(GameManager.instance.keyInteract) && !isInteracted)
        {
            if (GameManager.instance.gameState == GameState.Gameplay)
                Interact();
        }
    }

    private void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player") && Level5_Manager.instance.currentObjective == assignedObjective)
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

    protected virtual IEnumerator NextDialogue(string deactivation, int nextDialogue, Level1Objective nextObjective)
    {
        while (Level1_SoundManager.instance1.dialoguePlayer.isPlaying)
        {
            yield return null;
        }

        Level1_SoundManager.instance1.Say(nextDialogue);

        if (deactivation == "collider")
        {
            DeactivateCollider();
        }
        else if (deactivation == "object")
        {
            DeactivateObject();
        }

        Level1_Manager.instance.currentObjective = nextObjective;
    }
}
