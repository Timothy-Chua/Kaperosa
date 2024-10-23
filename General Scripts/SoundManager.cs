using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource dialoguePlayer;             // Where audio plays (set to camera)

    // Note: use a .txt file to keep track of dialogue and sfx index per level

    public DialogueObject[] dialogue;              // Array of dialogue objects (create in asset menu)
    public AudioClip[] sfx;                        // Array of sfx in level

    public AudioClip openDoorSFX;
    public AudioClip walkingSFX;

    public AudioClip interactSFX;

    protected virtual void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        dialoguePlayer = Camera.main.gameObject.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //dialoguePlayer = Camera.main.gameObject.GetComponent<AudioSource>();
        dialoguePlayer.volume = AudioManager.instance.volume;
        if (!dialoguePlayer.isActiveAndEnabled)
        {
            dialoguePlayer = Camera.main.gameObject.GetComponent<AudioSource>();
        }
    }

    public virtual void Say(int dialogueIndex)
    {
        DialogueObject currentDialogue = dialogue[dialogueIndex];

        if (dialoguePlayer.isPlaying)
            dialoguePlayer.Stop();

        // updates subtitle and clears after dialogue is complete
        Level1_UIManager.instance.SetSubtitle(currentDialogue.subtitle, currentDialogue.clip.length);

        // plays the called dialogue once with the set master volume (see AudioManager)
        dialoguePlayer.PlayOneShot(currentDialogue.clip, AudioManager.instance.volume);
    }

    public virtual void PlaySFX(int sfxIndex)
    {
        StartCoroutine(PlayOneSFX(sfx[sfxIndex]));
    }

    public virtual void PlaySFXWithoutFade(int sfxIndex)
    {
        StartCoroutine(PlayOneSfxWithoutFade(sfx[sfxIndex]));
    }

    public virtual void PlayMultipleDialogue(int startIndex, int endIndex)
    {
        StartCoroutine(PlayOneByOne(startIndex, endIndex, 0));
    }

    public virtual void PlayMultipleSFX(int startIndex, int endIndex)
    {
        StartCoroutine(PlayOneByOne(startIndex, endIndex, 1));
    }

    public virtual IEnumerator PlayOneSFX(AudioClip sfx)
    {
        Level1_UIManager.instance.Fade();

        dialoguePlayer.PlayOneShot(sfx, AudioManager.instance.volume);

        yield return new WaitForSeconds(sfx.length);

        Level1_UIManager.instance.Fade();
    }

    public virtual IEnumerator PlayOneSfxWithoutFade(AudioClip sfx)
    {
        dialoguePlayer.PlayOneShot(sfx, AudioManager.instance.volume);

        yield return new WaitForSeconds(sfx.length);
    }

    public virtual IEnumerator PlayOneByOne(int startIndex, int endIndex, int setNum)
    {
        if (setNum == 0)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                dialoguePlayer.clip = dialogue[i].clip;
                dialoguePlayer.Play();
                Level1_UIManager.instance.SetSubtitle(dialogue[i].subtitle, dialogue[i].clip.length);

                while (dialoguePlayer.isPlaying)
                {
                    yield return null;
                }

                yield return new WaitForSeconds(2f);
            }
        }
        else if (setNum == 1)
        {
            Level1_UIManager.instance.Fade();

            for (int i = startIndex; i <= endIndex; i++)
            {
                dialoguePlayer.clip = sfx[i];
                dialoguePlayer.Play();

                while (dialoguePlayer.isPlaying)
                {
                    yield return null;
                }
            }

            Level1_UIManager.instance.Fade();
        }
    }

    public void PlayInteract()
    {
        dialoguePlayer.PlayOneShot(interactSFX, AudioManager.instance.volume);
    }
}
