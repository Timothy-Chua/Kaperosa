using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4_SlideKaperosa : MonoBehaviour
{
    public GameObject obj;
    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    private void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            if (!isActive)
            {
                StartCoroutine(DelayScare());
                isActive = true;
            }
        }
    }

    private IEnumerator DelayScare()
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(3f);
        obj.SetActive(false);
    }
}
