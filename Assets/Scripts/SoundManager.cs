using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip ui;
    public AudioClip bombEffect;
    public AudioClip dia;

    AudioSource myAudio;
    public static SoundManager Instance;
    void Awake()
    {
        if (SoundManager.Instance == null)
            SoundManager.Instance = this;
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    
    public void Ui1Sound()
    {
        myAudio.PlayOneShot(ui);
    }
   
    public void BombEffect()
    {
        myAudio.PlayOneShot(bombEffect);
    }
    public void Getdia()
    {
        myAudio.PlayOneShot(dia);
    }
    public void EffectMute(bool isOn)
    {
        myAudio.mute = !isOn;
    }





}
