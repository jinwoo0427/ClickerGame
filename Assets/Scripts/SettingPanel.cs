using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    private Button QuitButton = null;
    [SerializeField]
    private Button BackSoundButton = null;
    [SerializeField]
    private Button SoundButton = null;
    [SerializeField]
    private Button GameHelpButton = null;


    public void OnClickQuit()
    {
        SoundManager.Instance.UiSound();
    
    }

    public void OnClickSoundButton()
    {
        SoundManager.Instance.UiSound();
    
    }

    public void OnClickBackSoundButton()
    {
        SoundManager.Instance.UiSound();

    }

    public void OnClickGameHelpButton()
    {
        SoundManager.Instance.UiSound();

    }

    
}
