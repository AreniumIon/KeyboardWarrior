using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSoundController : MonoBehaviour
{
    public static AudioSource PlayClip2D(AudioClip clip, float volume, bool canLoop = false)
    {
        //create
        GameObject audioObject = new GameObject("Audio2D");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.loop = canLoop;

        //configure
        audioSource.clip = clip;
        audioSource.volume = volume;

        //activate
        audioSource.Play();
        if (!canLoop)
        {
            Object.Destroy(audioObject, clip.length);
        }
        //return in case other things need it
        return audioSource;
    }
}
