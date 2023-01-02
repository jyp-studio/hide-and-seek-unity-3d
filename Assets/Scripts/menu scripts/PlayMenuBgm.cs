using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuBgm : MonoBehaviour
{
    public AudioClip bgm;
    void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<BgmPlayer>().PlayMusic(bgm);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
