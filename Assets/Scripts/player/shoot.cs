using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SojaExiles

{
    public class shoot : MonoBehaviour
    {
        public Camera fpscam;     //���Y
        public float range;
        public GameObject bullet;
        private AudioSource _audioSource;
        public AudioClip CorrectSound;
        public AudioClip Gun_shot;
        public int HP;
        public TextMeshProUGUI textHP;

        public string target = "Cube";  // �ؼЪ��� tag

        RaycastHit hit;      // �ƹ��p�g

        public float Delay = 0f;
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            HP = 30;
            DisplayHP(HP);
        }

        void Update()
        {
            Delay -= Time.deltaTime;  // ����ɶ�
            if (Input.GetMouseButtonDown(0) && Delay <= 0)
            {
                Delay = 0.5f;         // ����0.5��
                if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
                {
                    CorrectTest(hit);
                    // Debug.Log(hit.transform.name);  // ��������ؼ�
                    //  hit.collider.GetComponent<Renderer>().material.color = Color.green;  

                    SpawnDecal(hit, bullet);

                    DisplayHP((int)HP / 2);
                }
            }
        }

        void SpawnDecal(RaycastHit hit, GameObject prefab)    //�ͦ��l�u
        {
            GameObject spawedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
            spawedDecal.transform.SetParent(hit.collider.transform);
            Destroy(spawedDecal, 2);
        }

        void CorrectTest(RaycastHit hit)      // �P�_�O�_�����S�w����
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
                HP--;
            }
        }

        void DisplayHP(int hp)
        {
            Debug.Log(hp);
            textHP.text = "";
            for (int i = 0; i < hp; i++)
            {
                textHP.text += "/";
            }
        }
    }
}
