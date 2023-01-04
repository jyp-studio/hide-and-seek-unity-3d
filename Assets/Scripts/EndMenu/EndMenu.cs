using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public TextMeshProUGUI textTitle;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.isWin == true) textTitle.text = "You Win";
        else textTitle.text = "You Lose";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
