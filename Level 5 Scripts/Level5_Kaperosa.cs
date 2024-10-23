using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Level5_Kaperosa : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Taxi")
        {
            GameManager.instance.gameState = GameState.GameOver;
        }
    }
}
