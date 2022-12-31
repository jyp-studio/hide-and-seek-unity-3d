using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class shoot : MonoBehaviour
    {
        public Camera fpscam;     //鏡頭
        public float range;
        public GameObject bullet;
        private AudioSource _audioSource;
        public AudioClip CorrectSound;
        public AudioClip Gun_shot;

        public string target = "Cube";  // 目標物之 tag

        RaycastHit hit;      // 滑鼠雷射

        public float Delay = 0f;
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            Delay -= Time.deltaTime;  // 延遲時間
            if (Input.GetMouseButtonDown(0) && Delay <=0)
            {
                Delay = 0.5f;         // 延遲0.5秒
                if ( Physics.Raycast(fpscam.transform.position,fpscam.transform.forward , out hit ,range ))
               {
                    CorrectTest(hit);
                    // Debug.Log(hit.transform.name);  // 顯示擊中目標
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

        void CorrectTest(RaycastHit hit)      // 判斷是否擊中特定物件
        {
            if (hit.transform.tag == target)
            {
                Destroy(hit.transform.gameObject);
                _audioSource.clip = CorrectSound;
                _audioSource.Play();
            }
            else
            {
                _audioSource.clip = Gun_shot;
                _audioSource.Play();
            }
        }
    }
}
