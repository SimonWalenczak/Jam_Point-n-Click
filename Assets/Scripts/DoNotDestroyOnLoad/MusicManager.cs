using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public DontDestroyOnLoad _dontDestroyOnLoad;
    private AudioSource audioSource;
    public List<AudioClip> AudioClips;

    private bool isLaunch;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        DontDestroyOnLoad(this.gameObject);
        _dontDestroyOnLoad = GameObject.FindObjectOfType<DontDestroyOnLoad>();
    }

    private void Update()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(musicObj[1]);
        }

        if (_dontDestroyOnLoad.GameStep == 14 && isLaunch == false)
        {
            audioSource.clip = AudioClips[1];
            audioSource.Play();
            isLaunch = true;
        }
    }
}