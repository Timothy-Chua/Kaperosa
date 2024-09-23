using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6_Door : MonoBehaviour
{
    private Animator animator;
    private bool isOpen;
    public AudioSource audioSource;
    private bool isInteractable;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isOpen = false;

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        isInteractable = true;
    }

    protected virtual void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            Level1_UIManager.instance.txtInteract.text = "Press [E] to interact";
        }
    }

    protected virtual void OnTriggerStay(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            Interact();
        }
    }

    protected virtual void OnTriggerExit(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            Level1_UIManager.instance.txtInteract.text = string.Empty;
        }
    }

    protected virtual void Interact()
    {
        if (isInteractable)
        {
            StartCoroutine(DelayInteract());
            ToggleDoor();
            audioSource.PlayOneShot(SoundManager.instance.openDoorSFX, AudioManager.instance.volume);
        }
    }

    protected virtual void ToggleDoor()
    {
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }

    private IEnumerator DelayInteract()
    {
        isInteractable = false;
        yield return new WaitForSeconds(1f);
        isInteractable = true;
    }
}
