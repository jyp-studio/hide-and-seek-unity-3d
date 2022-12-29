using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class BtnStart : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI btnStart;
    public int SceneIndexDestination = 1;
    public void OnPointerEnter(PointerEventData e)
    {
        btnStart.fontStyle = FontStyles.Underline | FontStyles.SmallCaps;
    }
    public void OnPointerExit(PointerEventData e)
    {
        btnStart.fontStyle = FontStyles.SmallCaps;
    }

    public void OnPointerClick(PointerEventData e)
    {
        // get current scene
        Scene scene = SceneManager.GetActiveScene();

        // load a new scene
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
