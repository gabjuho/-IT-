using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource Sound;
    private void Awake()
    {
        Sound = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip getSound)
    {
        Sound.clip = getSound;
        Sound.Play();
    }
}
