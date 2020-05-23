using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Text scoreTxt;
    private int score;

    public GameObject gameOverPanel;
    public GameObject finalScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        scoreTxt = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = $"Score:\n{((int) Time.timeSinceLevelLoad) + score}";
    }

    public int Score {
        set { score += value; }
        get { return (int) Time.timeSinceLevelLoad + score; }
    }

    public void ShowGameOverPanel() {
        Time.timeScale = 0;
        finalScoreText.GetComponent<Text>().text = $"Final Score: {FindObjectOfType<GameController>().Score}";
        gameOverPanel.SetActive(true);
    }
}
