using System;
using UnityEngine;

public class AudioFin : MonoBehaviour
{
    private AudioSource _audioSource;

    public DontDestroyOnLoad _dontDestroyOnLoad;

    private void Awake()
    {
        _dontDestroyOnLoad = GameObject.FindObjectOfType<DontDestroyOnLoad>();
    }

    private void Update()
    {
        if (_dontDestroyOnLoad.GameStep == 14)
        {
            _audioSource.Play();
        }
    }
}
