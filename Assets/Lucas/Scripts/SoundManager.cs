using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource1;
    [SerializeField] private AudioSource _audioSource2;
    public void PlaySound(AudioClip clip)
    {
        if (!_audioSource1.isPlaying)
        {
            _audioSource1.clip = clip;
            _audioSource1.Play();
        }
        else if (!_audioSource1.isPlaying)
        {
            _audioSource2.clip = clip;
            _audioSource2.Play();
        }
    }
}
