using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public float speed;
    int health = 20;
    public static int score;

    public GameObject projectile;
    public SpriteRenderer spriteR;

    public Slider healthBarSlider;
    public Text helthBarText;
    public Text scoreText;

    public GameObject gameOverTxt;
    public GameObject restartB;
    public GameObject quitB;
    public GameObject blurry;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        InvokeRepeating("playBackgroundMusic", 0f, 13.241f);
    }

    // Update is called once per frame
    void Update()
    {   
        // Limit X axis
        if (transform.position.x <= -7.8f)
            transform.position = new Vector2(-7.8f, transform.position.y);
        else if (transform.position.x >= 7.8f)
            transform.position = new Vector2(7.8f, transform.position.y);
        
        // Limit Y axis
        if (transform.position.y <= -3.9f)
            transform.position = new Vector2(transform.position.x, -3.9f);
        else if (transform.position.y >= 3.9f)
            transform.position = new Vector2(transform.position.x, 3.9f);

        // Player Movement
        float x = 0, y = 0;
        x = speed * Input.GetAxis("Horizontal");
        y = speed * Input.GetAxis("Vertical");
        gameObject.transform.Translate(new Vector3(x, y, 0));

        // Shoot projectiles
        if (Input.GetKeyDown(KeyCode.J)) {
            Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            SoundManager.PlaySound("weaponPla");
        }

        // Kill player after health below 0
        if (health <= 0) {
            Destroy(gameObject);
            Time.timeScale = 0f;
            restartB.SetActive(true);
            quitB.SetActive(true);
            gameOverTxt.SetActive(true);
            blurry.SetActive(true);
        }

        // Update score
        scoreText.text = "SCORE: "+score;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("EnemyShot")) {
            --health;
        } else if (other.gameObject.tag.Equals("Enemy")) {
            health -= 2;
        } else if(other.gameObject.tag.Equals("Asteroid")) {
            health -= 5;
        }

        healthBarSlider.value = ((float) health)/20f;

        if (health >=0)
            helthBarText.text = health+"/20";
        else
            helthBarText.text = "0/20";

        if (!other.gameObject.tag.Equals("Projectile")) {
            spriteR.color = Color.red;
            StartCoroutine(CoroutineToRestartColor());
            SoundManager.PlaySound("playerEx");
        }
    }

    IEnumerator CoroutineToRestartColor() {
        yield return new WaitForSeconds(1f);
        spriteR.color = new Color(1, 1, 1, 1);
    }

    void playBackgroundMusic() {
        SoundManager.PlaySound("music");
    }
}
