using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level6_UIManager : Level1_UIManager
{
    [Header("Cutscene TV")]
    public string[] subtitles;
    public int cutsceneIndex = 0;

    public void NextCutsceneSubtitle()
    {
        SetSubtitle(subtitles[cutsceneIndex]);
        cutsceneIndex++;
    }

    public override void Fade()
    {
        isFade = !isFade;
        panelBlack.gameObject.GetComponent<Animator>().SetBool("isFade", isFade);

        if (GameManager.instance.gameState == GameState.Gameplay)
            GameManager.instance.gameState = GameState.Transiton;
        else if (GameManager.instance.gameState == GameState.Transiton)
            GameManager.instance.gameState = GameState.Gameplay;
    }
}
