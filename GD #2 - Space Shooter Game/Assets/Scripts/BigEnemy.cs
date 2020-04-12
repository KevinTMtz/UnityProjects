using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    public int health = 10;

    public GameObject enemyShot;
    public SpriteRenderer spriteR;

    public Rigidbody2D rigidBody;
    public Vector3 speed = new Vector3(0,-0.65f,0);
    public float yInicial = 7.5f;
    public float moveDistance;

    // Start is called before the first frame update
    void Start()
    {
        // Set lifetime
        Destroy(gameObject, 60f);
        
        moveDistance = 3f + Random.Range(0.0f, 3.0f);
        InvokeRepeating("InstantiateEnemyShot", 0f, 1.5f);

        // Set initial speed
        rigidBody.velocity = speed;

        StartCoroutine(CoroutineToSpeedAgain());
    }

    public bool checkIfStopped = true;

    // Update is called once per frame
    void Update()
    {
        // Kill big enemy after health below 0
        if (health <= 0) {
            Destroy(gameObject);
            Player.score += 100;
        }

        // Stop Enemy
        if (gameObject.transform.position.y <= yInicial-moveDistance && checkIfStopped) {
            rigidBody.velocity = new Vector3(0,0,0);
            checkIfStopped = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Projectile")) {
            --health;
            SoundManager.PlaySound("enemyEx");
        spriteR.color = Color.red;
            StartCoroutine(CoroutineToRestartColor());
        }
    }

    IEnumerator CoroutineToRestartColor() {
        yield return new WaitForSeconds(1f);
        spriteR.color = new Color(1, 1, 1, 1);
    }

    IEnumerator CoroutineToSpeedAgain() {
        yield return new WaitForSeconds(Random.Range(10f, 15f));
        rigidBody.velocity = new Vector3(0,Random.Range(-1.5f, -0.65f),0);
    }

    void InstantiateEnemyShot() {
        Instantiate(enemyShot, new Vector3(gameObject.transform.position.x-0.5f,gameObject.transform.position.y,0f), Quaternion.identity);
        Instantiate(enemyShot, new Vector3(gameObject.transform.position.x+0.5f,gameObject.transform.position.y,0f), Quaternion.identity);
        SoundManager.PlaySound("weaponEne");
    }
}
