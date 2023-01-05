using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using TMPro;

namespace SojaExiles

{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private Transform spawnedObject;
        private Transform spawnedObjectTransform;

        public TextMeshProUGUI textTest;
        public Camera cam;
        public CharacterController controller;

        public float speed = 5f;
        public float gravity = -15f;

        Vector3 velocity;

        bool isGrounded;

        private NetworkVariable<MyCustomData> randomNumber = new NetworkVariable<MyCustomData>(
            new MyCustomData
            {
                _int = 56,
                _bool = true,
            }, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

        public struct MyCustomData : INetworkSerializable
        {
            public int _int;
            public bool _bool;
            public FixedString128Bytes message;

            public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
            {
                serializer.SerializeValue(ref _int);
                serializer.SerializeValue(ref _bool);
                serializer.SerializeValue(ref message);
            }
        }

        public override void OnNetworkSpawn()
        {
            //if (!IsLocalPlayer) enabled = false;
            randomNumber.OnValueChanged += (MyCustomData previousValue, MyCustomData newValue) =>
            {
                Debug.Log(OwnerClientId + "; " + newValue._int + "; " + newValue._bool + "; " + newValue.message);
            };
        }

        void Start()
        {
            if (!IsLocalPlayer) cam.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

            if (!IsOwner) return;

            if (Input.GetKeyDown(KeyCode.T))
            {
                spawnedObjectTransform = Instantiate(spawnedObject);
                spawnedObjectTransform.GetComponent<NetworkObject>().Spawn(true);
                //TestServerRpc(new ServerRpcParams());
                //TestClientRpc(new ClientRpcParams { Send = new ClientRpcSendParams { TargetClientIds = new List<ulong> { 1 } } });
                /*
                randomNumber.Value = new MyCustomData
                {
                    _int = 10,
                    _bool = false,
                    message = "All your base are belong to us!"
                };
                */
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                //spawnedObjectTransform.GetComponent<NetworkObject>().De(true);
                Destroy(spawnedObjectTransform.gameObject);
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.I))
            {
                MessageServerRpc(1, "true"); // isWIn
                MessageServerRpc(2, "true"); // isGameEnd
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                MessageServerRpc(0, $"[ {Player.playerName} ]: hi");
            }
        }


        // [ServerRpc]
        // private void TestServerRpc(ServerRpcParams serverRpcParams)
        // {
        //     Debug.Log("TestServerRpc" + OwnerClientId + ", " + serverRpcParams.Receive.SenderClientId);
        // }

        // [ClientRpc]
        // private void TestClientRpc(ClientRpcParams clientRpcParams)
        // {
        //     Debug.Log("TestClientRpc");
        // }

        /*
        <summary> 
            A client will call ServerPrc() to tell a server do something,
            then the server will execute ClientRpc.
            That is, 
            ServerRpc is Client -> Server
            ClientRpc is Server -> Client 
        <summary/>

        code:
        0: set bool like activate a win scene
        1: send message
        */

        [ServerRpc(Delivery = RpcDelivery.Unreliable, RequireOwnership = false)]
        public void MessageServerRpc(int code, string message)
        {
            textTest.text += "calling server";
            MessageClientRpc(code, message);
        }

        [ClientRpc(Delivery = RpcDelivery.Unreliable)]
        public void MessageClientRpc(int code, string message = "")
        {
            textTest.text += "calling client";
            // if (IsOwner) return;
            switch (code)
            {
                case 0:
                    {
                        textTest.text += message;
                        textTest.text += "\r\n";
                        break;
                    }
                case 1:
                    {
                        bool value = message == "true" ? true : false;
                        GameManager.isWin = value;
                        break;
                    }
                case 2:
                    {
                        bool value = message == "true" ? true : false;
                        GameManager.isGameEnd = value;
                        break;
                    }
            }
        }
    }
}