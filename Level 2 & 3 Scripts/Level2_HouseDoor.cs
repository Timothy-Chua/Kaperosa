using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2_HouseDoor : Level2_DoorAnim
{
    public int nextScene = 3;

    protected override void Interact()
    {
        base.Interact();

        StartCoroutine(NextScene());
    }

    protected virtual IEnumerator NextScene()
    {
        Level1_UIManager.instance.Fade();

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(nextScene);
    }
}
