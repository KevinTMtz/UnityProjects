using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        //SceneManager.LoadScene(1);
        SoundManager.PlaySound("c2");
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void EndGame() {
        SoundManager.PlaySound("c2");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Restart() {
        SoundManager.PlaySound("c2");
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void QuitGame() {
        SoundManager.PlaySound("c2");
        Application.Quit();
    }
}
