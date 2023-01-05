using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgmPlayer : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip menuBgm;
    public AudioClip gameBgm;
    private bool isGameTime = false;

    private static BgmPlayer instance = null;
    public static BgmPlayer Instance
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
        bool lastGameTime = isGameTime;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            isGameTime = false;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            isGameTime = true;
        }

        if (isGameTime != lastGameTime) StopMusic();

        if (isGameTime)
        {
            PlayMusic(gameBgm);
        }
        else
        {
            PlayMusic(menuBgm);
        }
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
        if (_audioSource.isPlaying) _audioSource.Stop();
    }
}
