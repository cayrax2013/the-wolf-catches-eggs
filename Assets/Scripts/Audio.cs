using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _funMusic;
    [SerializeField] private AudioSource _startMusic;
    [SerializeField] private AudioSource _soundCollectedTheEgg;
    [SerializeField] private AudioSource _explosionSound;

    public void TurnOnFunMusic()
    {
        _startMusic.Stop();

        if (!_funMusic.isPlaying)
            _funMusic.Play();
    }

    public void TurnOnSoundCollectedTheeEgg()
    {
        _soundCollectedTheEgg.Play();
    }

    public void TurnOnExplosionsSound()
    {
        _explosionSound.Play();
    }
}
