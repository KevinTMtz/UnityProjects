using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Transform[] itemSpawners = new Transform[7];
    public GameObject coin;

    private GameObject coinInstantiated;
    private int scoreCount;

    public GameObject youWinPanel;
    public Text score;

    private PlayerDead playerDead;

    private int activeSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreCount = 0;
        activeSpawn = Random.Range(0, itemSpawners.Length);
        coinInstantiated = Instantiate(coin, itemSpawners[activeSpawn].position, Quaternion.identity);
        playerDead = FindObjectOfType<PlayerDead>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (coinInstantiated == null) {
            int temp = activeSpawn;
            while (activeSpawn == temp) {
                temp = Random.Range(0, itemSpawners.Length);
            }
            activeSpawn = temp;

            coinInstantiated = Instantiate(coin, itemSpawners[activeSpawn].position, Quaternion.identity);
            scoreCount += 1;
            score.text = "Score:\n" + scoreCount;
            playerDead.RestartTimer();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
            SoundManager.PlaySound("Positive");
        }

        if (scoreCount == 5 && Time.timeScale != 0) {
            YouWin();
        }
    }

    void YouWin() {
        Time.timeScale = 0;
        youWinPanel.SetActive(true);
        SoundManager.PlaySound("Win");
    }

    public Vector3 ActivePosition {
        get { return itemSpawners[activeSpawn].position; }
    }
}
