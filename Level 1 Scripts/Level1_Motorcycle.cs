using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level1_Motorcycle : Level1_Ambient
{
    public float delay = 30f;
    private float timer;

    protected override void Start()
    {
        base.Start();

        timer = 0f;
    }

    private void Update()
    {
        if (GameManager.instance.gameState == GameState.Gameplay)
        {
            timer += Time.deltaTime;

            if (timer >= delay)
            {
                audioSource.Play();
                timer = 0f;
            }
        }
    }
}
