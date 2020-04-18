using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButtons : MonoBehaviour
{
    private GameController gameController;
    
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    
    public void Play() {
        gameController.isPlaying = true;
    }

    public void Back() {
        gameController.isPlaying = false;
    }

    public void ClearCanvas() {
        foreach (Transform child in GameObject.Find("- Game Elements -").transform) {
           Destroy(child.gameObject);
        }

        foreach (Transform child in GameObject.Find("- Bullets -").transform) {
           Destroy(child.gameObject);
        }
    }

    public void Quit() {
        Application.Quit();
    }
}
