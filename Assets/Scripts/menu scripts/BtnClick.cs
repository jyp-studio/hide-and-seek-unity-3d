using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class BtnClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public int SceneIndexDestination = 2;
    public TextMeshProUGUI btn;
    private AudioSource _audioSource;
    public AudioClip selectingSound;
    public AudioClip pushingSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData e)
    {
        _audioSource.clip = selectingSound;
        _audioSource.volume *= 3;
        _audioSource.Play();
        btn.fontStyle = FontStyles.Underline | FontStyles.SmallCaps;
    }
    public void OnPointerExit(PointerEventData e)
    {
        btn.fontStyle = FontStyles.SmallCaps;
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
