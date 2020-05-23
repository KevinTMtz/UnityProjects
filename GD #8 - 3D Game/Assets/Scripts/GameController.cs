using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Text textPanelChickens;
    private Text textPanelWin;
    private int chickens = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        textPanelChickens = GameObject.Find("Text").GetComponent<Text>();
        textPanelWin = GameObject.Find("TextWin").GetComponent<Text>();
        textPanelWin.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (chickens == 3) {
            textPanelWin.text = "You Win!!!";
        }
    }

    public void KillChicken() {
        chickens++;
        textPanelChickens.text = $"Chickens: {chickens}/3";
    }
}
