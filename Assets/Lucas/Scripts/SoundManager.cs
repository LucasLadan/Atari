using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource1;
    [SerializeField] private AudioSource _audioSource2;
    private bool _firstSoundPlaying = false;
    private bool _secondSoundPlaying = false;
    public void PlaySound(AudioClip clip)
    {
        if (!_firstSoundPlaying)
        {
            _audioSource1.clip = clip;
            _audioSource1.Play();
            _firstSoundPlaying = true;
        }
        else if (!_secondSoundPlaying)
        {
            _audioSource2.clip = clip;
            _audioSource2.Play();
            _secondSoundPlaying = true;
        }
    }
}
