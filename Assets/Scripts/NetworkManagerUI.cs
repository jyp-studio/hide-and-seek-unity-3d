using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    private bool isSet = false;

    private void Update()
    {
        
        Debug.Log($"{Player.isHost}");
        
        if(!isSet){
            if (Player.isServer)
            {
                NetworkManager.Singleton.StartServer();
                isSet = true;
            }
            if (Player.isHost)
            {
                NetworkManager.Singleton.StartHost();
                isSet = true;
            }
            if (Player.isClient)
            {
                NetworkManager.Singleton.StartClient();
                isSet = true;
            }
        }
        /*
        serverBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
        });
        hostBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
        });
        clientBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
        });
        */
    }
}
