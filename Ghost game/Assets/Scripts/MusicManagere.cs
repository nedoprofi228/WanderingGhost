using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagere : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSrc => GetComponent<AudioSource>();
    public void PlayMusic(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 0.8f, float p2 = 1.2f)
    {
        audioSrc.pitch = Random.Range(p1, p2);
        audioSrc.PlayOneShot(clip);
    }
}
