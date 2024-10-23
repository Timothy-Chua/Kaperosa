using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5_HomeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Taxi") && Level5_Manager.instance.currentObjective == Level5Objective.Home)
        {
            StartCoroutine(LoadNextScene());
        }
    }

    IEnumerator LoadNextScene()
    {
        GameManager.instance.gameState = GameState.Transiton;
        Level5_UIManager.instance.Fade();

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(5);
    }
}
