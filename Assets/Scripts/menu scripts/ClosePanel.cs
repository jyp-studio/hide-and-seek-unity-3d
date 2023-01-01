using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ClosePanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData e)
    {
        panel.SetActive(false);
    }
}
