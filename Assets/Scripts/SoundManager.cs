using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip ui;
    public AudioClip uiend;

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

    public void UiSound()
    {
        myAudio.PlayOneShot(ui);
    }
    public void UiendSound()
    {
        myAudio.PlayOneShot(uiend);
    }
}
