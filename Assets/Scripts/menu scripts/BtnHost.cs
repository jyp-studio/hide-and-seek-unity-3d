using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BtnHost : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    // Start is called before the first frame update
    public GameObject btn;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isHost == false) { btn.GetComponent<Image>().color = Color.white; };
    }
    public void OnPointerClick(PointerEventData e)
    {
        Player.isHost = true;
        Player.isServer = false;
        Player.isClient = false;
        btn.GetComponent<Image>().color = Color.cyan;
    }
}
