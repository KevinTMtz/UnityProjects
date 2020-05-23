using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource startSound;
    public void PlayGame() {
        startSound.PlayOneShot(startSound.clip);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit(); 
    }
}
