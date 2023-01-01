using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BeHost : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public void OnPointerClick(PointerEventData e)
    {
        Player.isHost = true;
    }
}
