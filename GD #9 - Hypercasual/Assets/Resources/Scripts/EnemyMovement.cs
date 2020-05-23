using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
            gameObject.GetComponent<Animator>().SetTrigger("explote");
        }
    }

    public void AutoDestroy()
    {
        FindObjectOfType<GameController>().Score = 100;
        Destroy(gameObject);
    }
}
