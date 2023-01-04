using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace SojaExiles
{
    public class Quitgame : MonoBehaviour
    {
        [SerializeField]
        public int SceneIndexDestination = 5;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // get current scene
                Scene scene = SceneManager.GetActiveScene();

                // load a new scene
                SceneManager.LoadScene(SceneIndexDestination);
            }
        }
    }
}