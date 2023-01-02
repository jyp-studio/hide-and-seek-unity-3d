using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPushingPlayer : MonoBehaviour
{
    public AudioSource _audioSource;

    private static BtnPushingPlayer instance = null;
    public static BtnPushingPlayer Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayOneShotMusic(AudioClip source)
    {
        _audioSource.PlayOneShot(source);
    }

    public void PlayMusic(AudioClip source)
    {
        if (_audioSource.isPlaying) return;
        _audioSource.clip = source;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
