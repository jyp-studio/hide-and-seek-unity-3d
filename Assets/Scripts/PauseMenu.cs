using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause) Resume();
            else Pause();
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPause = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
