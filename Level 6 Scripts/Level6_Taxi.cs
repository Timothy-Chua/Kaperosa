using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Level6_Taxi : Level6_Interact
{
    public Camera cameraCutscene;
    public GameObject playerObj;
    public VideoPlayer player;

    protected override void Interact()
    {
        base.Interact();
        ClearInteract();

        //director.Play();

        PlayVideo();
    }

    private void PlayVideo()
    {
        player.SetDirectAudioVolume(0, AudioManager.instance.volume);
        StartCoroutine(CutsceneFinal());
    }

    private IEnumerator CutsceneFinal()
    {
        GameManager.instance.gameState = GameState.Transiton;
        playerObj.GetComponent<PlayerControl>().feetSource.Stop();
        playerObj.SetActive(false);
        cameraCutscene.gameObject.SetActive(true);
        player.Play();

        yield return new WaitForSeconds((float)player.clip.length);

        SceneManager.LoadScene(6);
    }
}
