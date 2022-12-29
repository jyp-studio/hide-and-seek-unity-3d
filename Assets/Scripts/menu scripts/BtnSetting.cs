using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class BtnSetting : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int SceneIndexDestination = 3;

    public void OnPointerEnter(PointerEventData e)
    {

    }
    public void OnPointerExit(PointerEventData e)
    {

    }
    public void OnPointerClick(PointerEventData e)
    {
        // get current scene
        Scene scene = SceneManager.GetActiveScene();

        // load a new scene
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
