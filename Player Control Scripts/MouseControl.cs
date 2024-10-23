using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float xSensitivity = 50f; 
    public float ySensitivity = 10f;
    [SerializeField] private Transform playerBody;
    private float xRotation;
    float xAccumulator;
    float yAccumulator;

    private void Start()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (GameManager.instance.gameState == GameState.Gameplay)
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");

            xAccumulator = Mathf.Lerp(xAccumulator, mouseX, xSensitivity * Time.deltaTime);
            yAccumulator = Mathf.Lerp(yAccumulator, mouseY, ySensitivity * Time.deltaTime);

            xRotation -= yAccumulator;
            xRotation = ClampRotation(xRotation);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.gameState == GameState.Gameplay)
        {
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * xAccumulator);
        }
    }

    private float ClampRotation(float rotation)
    {
        if (rotation > 45f)
        {
            return 45f;
        }
        else if (rotation < -90f)
        {
            return -90f;
        }
        else
        {
            return rotation;
        }
    }
}
