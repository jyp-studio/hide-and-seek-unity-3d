using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace SojaExiles

{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private Transform spawnedObject;
        private Transform spawnedObjectTransform;

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
            randomNumber.OnValueChanged += (MyCustomData previousValue, MyCustomData newValue) =>
            {
                Debug.Log(OwnerClientId + "; " + newValue._int + "; " + newValue._bool + "; " + newValue.message);
            };
        }

        void Start()
        {
            //if (!IsLocalPlayer) cam.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

            //if (!IsOwner) return;

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

        }


        [ServerRpc]
        private void TestServerRpc(ServerRpcParams serverRpcParams)
        {
            Debug.Log("TestServerRpc" + OwnerClientId + ", " + serverRpcParams.Receive.SenderClientId);
        }

        [ClientRpc]
        private void TestClientRpc(ClientRpcParams clientRpcParams)
        {
            Debug.Log("TestClientRpc");
        }

        
    }
}