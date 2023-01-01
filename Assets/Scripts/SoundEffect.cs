using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioClip soundeffect;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip source)
    {
        // if (_audioSource.isPlaying) return;
        _audioSource.PlayOneShot(source);
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
