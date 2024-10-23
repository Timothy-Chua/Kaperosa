using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4_NextScene : Level4_Interact
{
    public int nextSceneIndex;

    protected override void Interact()
    {
        base.Interact();

        isInteracted = true;

        StartCoroutine(NextScene());
    }

    protected virtual IEnumerator NextScene()
    {
        Level1_UIManager.instance.Fade();

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(nextSceneIndex);
    }
}
