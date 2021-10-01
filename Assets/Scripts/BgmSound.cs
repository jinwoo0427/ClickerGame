using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSound : MonoBehaviour
{
    public AudioClip bgm;

    AudioSource bgmaudio;
    public static BgmSound Instance;
    void Awake()
    {
        if (BgmSound.Instance == null)
            BgmSound.Instance = this;
    }

    void Start()
    {
        bgmaudio = GetComponent<AudioSource>();
    }
    //public void BgmPlay()
    //{
    //    bgmaudio.Play();
    //}
    public void BgmMute(bool ison)
    {
        bgmaudio.mute = !ison;
    }


}
