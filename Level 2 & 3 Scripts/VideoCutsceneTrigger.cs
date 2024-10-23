using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoCutsceneTrigger : MonoBehaviour
{
    public Camera startCam;
    public GameObject playerObj;
    public Vector3 endPos;
    private VideoPlayer player;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
    }

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Taxi") || actor.gameObject.CompareTag("Player"))
        {
            player.SetDirectAudioVolume(0, AudioManager.instance.volume);
            PlayVideo();
        }
    }

    protected virtual void PlayVideo()
    {
        StartCoroutine(PlayVid());
    }

    protected virtual IEnumerator PlayVid()
    {
        startCam.gameObject.SetActive(true);
        playerObj.SetActive(false);
        playerObj.transform.position = endPos;

        GameManager.instance.gameState = GameState.Transiton;

        player.Play();

        yield return new WaitForSeconds((float)player.clip.length);

        Pause.instance._BtnPause();
        player.Stop();
        startCam.gameObject.SetActive(false);
        playerObj.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
