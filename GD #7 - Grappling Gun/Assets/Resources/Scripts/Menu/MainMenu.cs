using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() {
        FindObjectOfType<SoundManager>().StopAllSongs();
        FindObjectOfType<SoundManager>().Play("Rise");
    }
    
    public void PlayGame() {
        SceneManager.LoadScene("Game");
        SoundManager.PlaySound("Positive");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
