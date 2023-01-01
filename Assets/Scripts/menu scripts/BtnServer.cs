using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BtnServer : MonoBehaviour, IPointerClickHandler
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
        if (Player.isServer == false) { btn.GetComponent<Image>().color = Color.white; };
    }
    public void OnPointerClick(PointerEventData e)
    {
        Player.isServer = true;
        Player.isClient = false;
        Player.isHost = false;
        btn.GetComponent<Image>().color = Color.cyan;
    }
}
