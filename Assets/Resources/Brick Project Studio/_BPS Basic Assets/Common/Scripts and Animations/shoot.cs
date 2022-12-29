using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class shoot : MonoBehaviour
    {
        public Camera fpscam;
        public float range;
        public GameObject bullet; 
        void Start()
        {

        }

        void Update()
        {
            
            if (Input.GetMouseButtonDown(0))
            {

                Debug.Log("shooting");
                RaycastHit hit;
               if( Physics.Raycast(fpscam.transform.position,fpscam.transform.forward , out hit ,range ))
               {
                    Debug.Log(hit.transform.name);  // ��������ؼ�
                    //  hit.collider.GetComponent<Renderer>().material.color = Color.green;  
                    SpawnDecal(hit, bullet);
                }
            }
        }

        void SpawnDecal(RaycastHit hit , GameObject prefab)    //�ͦ��l�u
        {
            GameObject spawedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
            spawedDecal.transform.SetParent(hit.collider.transform);
        }
    }
}
