using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour
{
    public Camera startCam;
    public GameObject playerObj;
    public float startDelay = 5f;
    private VideoPlayer player;

    private void Awake()
    {
        player = GetComponent<VideoPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player.SetDirectAudioVolume(0, AudioManager.instance.volume);
        StartCoroutine(PlayVid());
    }

    private IEnumerator PlayVid()
    {
        GameManager.instance.gameState = GameState.Transiton;

        //yield return new WaitForSeconds(startDelay);
        
        player.Play();

        yield return new WaitForSeconds((float) player.clip.length);

        Pause.instance._BtnPause();
        player.Stop();
        startCam.gameObject.SetActive(false);
        playerObj.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
