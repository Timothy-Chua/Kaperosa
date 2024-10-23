using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_UIManager : Level1_UIManager
{
    [Header("Cutscene TV")]
    public string[] subtitles;
    public int cutsceneIndex = 0;

    public void NextCutsceneSubtitle()
    {
        SetSubtitle(subtitles[cutsceneIndex]);
        cutsceneIndex++;
    }
}
