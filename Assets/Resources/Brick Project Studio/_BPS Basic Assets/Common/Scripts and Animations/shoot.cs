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

        public AudioSource Gun_shot;
        void Start()
        {
            Gun_shot = GetComponent<AudioSource>();
        }

        void Update()
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                Gun_shot.Play();
                RaycastHit hit;
               if( Physics.Raycast(fpscam.transform.position,fpscam.transform.forward , out hit ,range ))
               {
                    Debug.Log(hit.transform.name);  // 顯示擊中目標
                //  hit.collider.GetComponent<Renderer>().material.color = Color.green;  
                    SpawnDecal(hit, bullet);
                }
            }
        }

        void SpawnDecal(RaycastHit hit , GameObject prefab)    //生成子彈
        {
            GameObject spawedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
            spawedDecal.transform.SetParent(hit.collider.transform);
            Destroy(spawedDecal,2);
        }
    }
}
