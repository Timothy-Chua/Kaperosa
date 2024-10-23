using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public AudioSource feetSource;
    private CharacterController playerController;

    [SerializeField] private float speed;
    private float gravity = -19.62f;
    private Vector3 velocity;

    [SerializeField] private PlayerState playerState;
    private bool isSFXTriggered;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerState = PlayerState.Idle;

        feetSource.clip = SoundManager.instance.walkingSFX;
        isSFXTriggered = false;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.gameState == GameState.Gameplay)
        {
            PlayerMovement();
        }    
    }

    private void Update()
    {
        if (GameManager.instance.gameState != GameState.Gameplay)
        {
            playerController.enabled = false;
            playerState = PlayerState.Idle;
        }
        else
        {
            playerController.enabled = true;
        }

        feetSource.volume = AudioManager.instance.volume;

        if (playerState == PlayerState.Walking)
        {
            if (!isSFXTriggered)
            {
                feetSource.Play();
                isSFXTriggered = true;
            }
        }
        else
        {
            feetSource.Stop();
            isSFXTriggered = false;
        }
    }

    private enum PlayerState
    {
        Idle,
        Walking,
    }

    private void PlayerMovement()
    {
        playerController.enabled = true;

        if(velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        float moveMagnitude = move.magnitude;

        if (moveMagnitude > 0)
        {
            playerState = PlayerState.Walking;
            move *= speed;
        }
        else
        {
            playerState = PlayerState.Idle;
        }

        playerController.Move(move * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
