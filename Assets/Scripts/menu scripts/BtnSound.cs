using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnSound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    public Button btn;
    private AudioSource _audioSource;
    public AudioClip selectingSound;
    public AudioClip pushingSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData e)
    {
        if (selectingSound)
        {
            GameObject.FindGameObjectWithTag("SelectingSound").GetComponent<BtnSelectingPlayer>().PlayOneShotMusic(selectingSound);
        }
    }
    public void OnPointerExit(PointerEventData e)
    {
    }
    public void OnPointerClick(PointerEventData e)
    {
        if (pushingSound)
        {
            GameObject.FindGameObjectWithTag("PushingSound").GetComponent<BtnPushingPlayer>().PlayOneShotMusic(pushingSound);
        }
    }
}
