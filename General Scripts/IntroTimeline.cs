using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class IntroTimeline : MonoBehaviour
{
    public PlayableDirector director;
    public float delay = 15f;
    public Camera startCam;
    public GameObject car;
    private Vector3 startPos;

    private void Awake()
    {
        startPos = car.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.gameState = GameState.Transiton;
        StartCoroutine(PlayDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayDelay()
    {
        Debug.Log("Started");
        yield return new WaitForSeconds(delay);

        Debug.Log("Play");

        startCam.gameObject.SetActive(false);
        car.SetActive(true);
        car.transform.position = startPos;

        yield return new WaitForSeconds(0.25f);

        car.transform.position = startPos;
        director.gameObject.SetActive(true);
    }
}
