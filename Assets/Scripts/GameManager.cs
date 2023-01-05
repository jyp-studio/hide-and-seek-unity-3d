using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using SojaExiles;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textAlert;
    public TextMeshProUGUI textHP;
    public static int playerHP = 4;
    public static bool isHiding = false;
    public static bool isFinding = false;
    public static bool isGameEnd = false;
    public static bool isWin = false; // if this player is win or not
    public static int hidingTime = 10;
    public static int findingTime = 300;

    private float countDown = 3;
    private bool startCountDown = false;
    private bool startGame = false;

    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        textAlert.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (isHiding)
        {
            textAlert.text = "You are a ";
            textAlert.text += Player.isHunter ? "Hunter" : "Ranger";
        }
        if (isFinding)
        {
            if (!startGame)
            {
                textAlert.text = "Start!";
                startCountDown = true;
            }
            else
            {
                textAlert.text = "";
            }
        }

        if (startCountDown)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                countDown = 0;
                startGame = true;
            }
        }

        // display player hp
        if (playerHP > 0)
        {
            DisplayHP((int)playerHP / 2);
        }
        else
        {
            playerHP = 0;
            DisplayHP((int)playerHP);

            // set ranger's isWin = true
            GameObject.FindGameObjectWithTag("Ranger").GetComponent<PlayerMovement>().MessageServerRpc(1, "true");
            // tell other's that game is end
            GameObject.FindGameObjectWithTag("Ranger").GetComponent<PlayerMovement>().MessageServerRpc(2, "true");
            isGameEnd = true;

        }

        // end game load end game scene
        if (isGameEnd)
        {
            // set variables back
            playerHP = 10;
            isHiding = false;
            isFinding = false;
            isGameEnd = false;
            isWin = false;
            startCountDown = false;
            startGame = false;

            // unlock mouse
            Cursor.lockState = CursorLockMode.None;

            // load the end scene
            SceneManager.LoadScene(5);

            // destroy network manager
            Destroy(GameObject.Find("NetworkManager"));

            // destroy game manager
            Destroy(this.gameObject);
        }
    }

    void DisplayHP(int hp)
    {
        // Debug.Log(hp);
        textHP.text = "";
        for (int i = 0; i < hp; i++)
        {
            textHP.text += "/";
        }
    }
}
