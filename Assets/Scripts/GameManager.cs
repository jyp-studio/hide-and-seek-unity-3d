using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI textAlert;
    public TextMeshProUGUI textHP;
    public static int playerHP = 20;
    public static bool isHiding = false;
    public static bool isFinding = false;
    public static bool isGameEnd = false;
    public static bool isWin = false; // if this player is win or not
    public static int hidingTime = 10;
    public static int findingTime = 3000;

    private float countDown = 5;
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
            isGameEnd = true;

            // load the end scene
            SceneManager.LoadScene(5);
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
