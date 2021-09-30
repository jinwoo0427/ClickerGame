using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    public void GoGameScene()
    {
        //SoundManager.instance.UiSound();
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        //SoundManager.instance.UiSound();
        Application.Quit();
    }



}
