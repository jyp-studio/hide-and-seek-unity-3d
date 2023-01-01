using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class ConfirmPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public TextMeshProUGUI console;
    public TMP_InputField inputField;
    public GameObject panel;
    public int SceneIndexDestination = 2;
    private bool refresh = false;
    // Start is called before the first frame update
    void Start()
    {
        console.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (refresh == true) { console.text = ""; };
    }
    public void OnPointerClick(PointerEventData e)
    {
        string name = inputField.text.Trim();

        // check if input name is valid
        if (string.IsNullOrWhiteSpace(name))
        {
            console.text = "Should not be empty.";
            inputField.text = "";
            return;
        }
        if (name.Length > 10)
        {
            console.text = "Exceed 10 characters.";
            inputField.text = "";
            return;
        }
        Player.playerName = name;
        panel.SetActive(false);
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
