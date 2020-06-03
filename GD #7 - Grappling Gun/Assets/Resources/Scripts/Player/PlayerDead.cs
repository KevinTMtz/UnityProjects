using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    private Transform spawnerTransform;

    private DistanceJoint2D joint;
    private LineRenderer line;
    private GrapplingHook grapplingHook;
    private Rigidbody2D rb;

    private int playerLives;
    private float timeLeft;
    public Text time;
    public Text lives;

    public GameObject gameOverPanel;

    private bool ableToDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        ableToDamage = true;
        Time.timeScale = 1;
        spawnerTransform = GameObject.Find("PlayerSpawner").transform;
        joint = GetComponent<DistanceJoint2D>();
        line = GameObject.Find("LineRenderer").GetComponent<LineRenderer>();
        grapplingHook = FindObjectOfType<GrapplingHook>();
        rb = GetComponent<Rigidbody2D>();

        RestartTimer();

        playerLives = 3;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Time.timeScale != 0) {
            timeLeft -= Time.deltaTime;
            
            time.text = string.Format("Remaining time: {0:#.00} s", timeLeft);
        }

        if (timeLeft <= 5) {
            time.color = Color.red;
        }
        
        if (timeLeft <= 0 && Time.timeScale != 0) {
            time.text = "Remaining time: 0.00 s";
            GameOver();
        }
    }

    void GameOver() {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        SoundManager.PlaySound("GameOver");
    }

    public void RestartTimer() {
        time.color = Color.white;
        timeLeft = 35f;
    }

    IEnumerator WaitToReceiveDamage()
    {
        yield return new WaitForSeconds(1);
        ableToDamage = true;
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy")  && ableToDamage) {
            StartCoroutine(WaitToReceiveDamage());
            ableToDamage = false;
            transform.position = spawnerTransform.position;
            rb.velocity = new Vector2(0,0);

            joint.autoConfigureDistance = true;
            joint.enabled = false;
            line.SetPosition(0, new Vector3(0, 0, 0));
            line.SetPosition(1, new Vector3(0, 0, 0));

            grapplingHook.IsHookActive = false;

            SoundManager.PlaySound("Dead");

            playerLives -= 1;
            lives.text = "Lives: " + playerLives;

            if (playerLives == 0) {
                GameOver();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Enemy") && ableToDamage) {
            StartCoroutine(WaitToReceiveDamage());
            ableToDamage = false;
            transform.position = spawnerTransform.position;
            rb.velocity = new Vector2(0,0);

            joint.autoConfigureDistance = true;
            joint.enabled = false;
            line.SetPosition(0, new Vector3(0, 0, 0));
            line.SetPosition(1, new Vector3(0, 0, 0));

            grapplingHook.IsHookActive = false;

            SoundManager.PlaySound("Dead");

            playerLives -= 1;
            lives.text = "Lives: " + playerLives;

            if (playerLives == 0) {
                GameOver();
            }
        }
    }
}
