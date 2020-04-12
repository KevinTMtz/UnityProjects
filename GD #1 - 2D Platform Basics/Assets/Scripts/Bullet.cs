using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;

    public Animator animator;

    public GameObject otherGameObject;
    public Animator otherAni;
    public Rigidbody2D anotherRigidBody;
    public BoxCollider2D enemyCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Enemy")) {
            otherGameObject = other.gameObject;
            otherAni = otherGameObject.GetComponent<Animator> ();
            anotherRigidBody = otherGameObject.GetComponent<Rigidbody2D>();
            enemyCollider = otherGameObject.GetComponent<BoxCollider2D>();

            anotherRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            otherAni.Play("Dead");
            enemyCollider.isTrigger = true;
            Destroy (otherGameObject, 0.4f); 

            //Destroy(gameObject);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            gameObject.transform.localScale -= new Vector3(0.7f, 0.7f, 0.7f);
            animator.Play("BulletExplosion");
            StartCoroutine(CoroutineToKillObject());
            SoundManager.PlaySound("h1");
        } else if (!other.gameObject.tag.Equals("Player")&&!other.gameObject.tag.Equals("Bullet")) {
            //Destroy(gameObject);
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            gameObject.transform.localScale -= new Vector3(0.7f, 0.7f, 0.7f);
            animator.Play("BulletExplosion");
            StartCoroutine(CoroutineToKillObject());
            SoundManager.PlaySound("h1");
        }
    }

    IEnumerator CoroutineToKillObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
