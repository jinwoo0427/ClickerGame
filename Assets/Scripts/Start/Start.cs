using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void GoGameScene()
    {
        SoundManager.Instance.Ui1Sound();
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        SoundManager.Instance.Ui1Sound();
        Application.Quit();
    }



}
