using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_Door : MonoBehaviour
{
    [SerializeField] private float openAngle;
    [SerializeField] private float closeAngle = 0f;
    [SerializeField] private float smooth = 0.5f;
    private KeyCode interactKey = KeyCode.E;

    private Quaternion openRotation;
    private Quaternion closeRotation;
    private bool isOpen;
    private bool canUse;

    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    private AudioSource audioPlayer;

    // or make it interactable ? 

    private void Start()
    {
        if(gameObject.name == "CrDoor")
        {
            openAngle = -90f;
            openRotation = Quaternion.Euler(-90, 0, openAngle);
            closeRotation = Quaternion.Euler(-90, 0, closeAngle);
        }
        canUse = true;
        audioPlayer = GetComponent<AudioSource>();
        isOpen = false;
    }

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player") && canUse)
        {
            if (gameObject.name == "ExitDoor")
            {
                if (Level1_Manager.instance.currentObjective == Level1Objective.exit)
                {
                    Level1_UIManager.instance.txtInteract.text = "Press [E] to interact";
                }
            }
            else
            {
                Level1_UIManager.instance.txtInteract.text = "Press [E] to interact";
            }
        }
    }

    private void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player") && Input.GetKeyDown(interactKey) && canUse)
        {
            if (Level1_Manager.instance.currentObjective == Level1Objective.exit && gameObject.name == "ExitDoor")
            {
                audioPlayer.PlayOneShot(openSound);
                SceneManager.LoadScene("Level 2");
            }
            else if (gameObject.name == "CrDoor")
            {
                canUse = false;
                ToggleDoor();
            }
        }
    }

    private void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            Level1_UIManager.instance.txtInteract.text = string.Empty;
        }
    }

    private void ToggleDoor()
    {
        isOpen = !isOpen;

        Quaternion targetRotation = isOpen ? openRotation : closeRotation;
        StartCoroutine(AnimateDoor(targetRotation));
    }

    private IEnumerator AnimateDoor(Quaternion targetRotation)
    {
        

        Quaternion initialRotation = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < smooth)
        {
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime / smooth);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (isOpen)
        {
            audioPlayer.PlayOneShot(openSound);
        }
        else
        {
            audioPlayer.PlayOneShot(closeSound);
        }

        transform.rotation = targetRotation;
        canUse = true;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        canUse = true;
    }
}
