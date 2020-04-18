using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject enemyDeath;
    public GameObject bulletExplosion;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Enemy")) {
            Destroy(other.gameObject);
            Transform otherTransform = other.gameObject.transform;
            Instantiate(enemyDeath, otherTransform.position, otherTransform.transform.rotation);
        }

        if (!other.gameObject.tag.Equals("Player") && !other.gameObject.tag.Equals("Transparent")) {
            Destroy(gameObject);
            Instantiate(bulletExplosion, transform.position, transform.rotation);
        }
    }
}
