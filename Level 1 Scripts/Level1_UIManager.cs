using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level1_UIManager : MonoBehaviour
{
    public static Level1_UIManager instance;

    public TextMeshProUGUI txtInteract;
    public TextMeshProUGUI txtSubtitle;

    public GameObject panelBlack;
    protected bool isFade;

    protected virtual void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        txtInteract.text = string.Empty;

        isFade = false;
    }

    public virtual void SetSubtitle(string subtitle)
    {
        txtSubtitle.text = subtitle;
    }

    public virtual void SetSubtitle(string subtitle, float delay)
    {
        // Sets subtitle to assigned string (see SoundManager)
        txtSubtitle.text = subtitle;
        StartCoroutine(ClearAfterSeconds(delay));
    }

    public virtual void ClearSubtitle()
    {
        txtSubtitle.text = string.Empty;
    }

    public virtual IEnumerator ClearAfterSeconds(float delay)
    {
        // Clears subtitle after delay = clip length (see SoundManager)
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }

    public virtual void Fade()
    {
        isFade = !isFade;
        panelBlack.gameObject.GetComponent<Animator>().SetBool("isFade", isFade);

        if (GameManager.instance.gameState == GameState.Gameplay)
            GameManager.instance.gameState = GameState.Transiton;
        else if (GameManager.instance.gameState == GameState.Transiton)
            GameManager.instance.gameState = GameState.Gameplay;
    }
}
