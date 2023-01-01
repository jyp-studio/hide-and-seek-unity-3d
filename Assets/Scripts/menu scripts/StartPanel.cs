using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class StartPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public GameObject panel;
    public TextMeshProUGUI console;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData e)
    {
        panel.SetActive(true);
        console.text = "";
    }
}
