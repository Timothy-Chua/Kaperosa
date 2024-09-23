using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [SerializeField] TMP_Text interactionText;

    public void EnableInteractionText(string text)
    {
        interactionText.text = "PRESS E TO INTERACT " + text;
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText() 
    {
        interactionText.gameObject.SetActive(false);
    }
}
