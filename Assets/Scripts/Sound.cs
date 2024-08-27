﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector]public AudioSource audioSource;
    public string name;
    public AudioClip clip;
    [Range(0f,2f)]public float volume;
    [Range(.1f, 3f)] public float pitch;

}
