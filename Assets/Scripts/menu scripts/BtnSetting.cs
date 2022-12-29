using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnSetting : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int SceneIndexDestination = 3;
    private AudioSource _audioSource;
    public AudioClip selectingSound;
    public AudioClip pushingSound;
    public Image image;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        image.GetComponent<Image>().color = new Color32(138, 85, 26, 255);
    }

    public void OnPointerEnter(PointerEventData e)
    {
        _audioSource.clip = selectingSound;
        _audioSource.volume *= 3;
        _audioSource.Play();

        image.GetComponent<Image>().color = new Color32(77, 45, 15, 255);


    }
    public void OnPointerExit(PointerEventData e)
    {
        image.GetComponent<Image>().color = new Color32(138, 85, 26, 255);
    }
    public void OnPointerClick(PointerEventData e)
    {
        _audioSource.clip = pushingSound;
        _audioSource.Play();

        // get current scene
        Scene scene = SceneManager.GetActiveScene();

        // load a new scene
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
