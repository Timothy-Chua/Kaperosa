using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 200f;
    private float xRotation = 0f;

    private void Start()
    {
        xRotation = -90f;
    }

    private void LateUpdate()
    {
        if (GameManager.instance.gameState == GameState.Gameplay)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

            xRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -90, 60f);

            transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
        }
    }
}
