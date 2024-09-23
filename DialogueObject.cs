using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Object", menuName = "Scriptable Audio/New Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    public AudioClip clip;
    public string subtitle;
}
