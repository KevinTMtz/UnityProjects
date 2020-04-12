using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    public GameObject enemyShot;
    public SpriteRenderer spriteR;

    public float speedOnY;
    public float amplitude;
    public float frequenz;
    public float xInicial;

    // Start is called before the first frame update
    void Start()
    {
        // Set lifetime
        Destroy(gameObject, 20f);

        xInicial = gameObject.transform.position.x;
        speedOnY = Random.Range(-1.25f, -0.75f);
        amplitude = Random.Range(1f, 3f);

        InvokeRepeating("InstantiateEnemyShot", 0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Kill big enemy after health below 0
        if (health <= 0) {
            Destroy(gameObject);
            Player.score += 10;
        }

        // Enemy Movement
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y;

        y = y + speedOnY * Time.deltaTime;
        x = Mathf.Sin(y*frequenz)*amplitude + xInicial;
        gameObject.transform.position = new Vector3(x,y,0);
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

    void InstantiateEnemyShot() {
        Instantiate(enemyShot, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,0f), Quaternion.identity);
        SoundManager.PlaySound("weaponEne");
    }
}
