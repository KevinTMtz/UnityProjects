using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1f;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
