using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SojaExiles;

public class PlayerMenu : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject chatRoom;
    private bool istyping = false;
    private bool isOpenChatRoom = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (istyping)
            {
                string words = $"[{Player.playerName}]: {inputField.text}";
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MessageServerRpc(0, words);
                inputField.text = "";
                inputField.Select();
                // inputField.enabled = false;
                istyping = false;
            }
            else
            {
                // inputField.enabled = true;
                inputField.Select();
                istyping = true;
            }
        }
    }
}
