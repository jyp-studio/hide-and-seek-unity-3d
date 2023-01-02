using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BtnReaction : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public TextMeshProUGUI btn;
    private AudioSource _audioSource;
    public AudioClip selectingSound;
    public AudioClip pushingSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        btn.fontStyle = FontStyles.SmallCaps;
    }

    public void OnPointerEnter(PointerEventData e)
    {
        GameObject.FindGameObjectWithTag("SelectingSound").GetComponent<BtnSelectingPlayer>().PlayOneShotMusic(selectingSound);
        btn.fontStyle = FontStyles.Underline | FontStyles.SmallCaps;
    }
    public void OnPointerExit(PointerEventData e)
    {
        btn.fontStyle = FontStyles.SmallCaps;
    }
    public void OnPointerClick(PointerEventData e)
    {
        btn.fontStyle = FontStyles.SmallCaps;
        GameObject.FindGameObjectWithTag("PushingSound").GetComponent<BtnPushingPlayer>().PlayOneShotMusic(pushingSound);
    }
}
