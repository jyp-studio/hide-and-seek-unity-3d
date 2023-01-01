using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public int SceneIndexDestination = 2;

    void Start()
    {
    }
    public void OnPointerClick(PointerEventData e)
    {
        if (SceneIndexDestination >= 0)
        {
            SwitchScene(SceneIndexDestination);
        }

    }

    private void SwitchScene(int sceneIndex)
    {
        // get current scene
        Scene scene = SceneManager.GetActiveScene();

        // load a new scene
        SceneManager.LoadScene(sceneIndex);
    }
}
