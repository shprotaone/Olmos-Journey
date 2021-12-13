using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource[] _audioSources;

    //[0] - sliding
    //[1] - left
    //[2] - right

    private void Awake()
    {
        _audioSources = GetComponents<AudioSource>();
    }

    public void StartSliding(bool play)
    {
        //if(_audioSources != null)
        //{
        //    if (play)
        //        _audioSources[0].Play();
        //    else
        //        _audioSources[0].Stop();
        //}
        //else
        //{
        //    print("AudioSource null");
        //}

    }

    public void TurnSound(bool left)
    {
        //if(_audioSources != null)
        //{
        //    if (left)
        //        _audioSources[1].Play();
        //    else
        //        _audioSources[2].Play();
        //}
        //else
        //{
        //    print("AudiSource null ");
        //}

    }
}
