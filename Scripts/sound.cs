using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class sound
{
    public string name;

    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

}
