using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Vector3 speed = new Vector3(0,5,0); 
    
    // Start is called before the first frame update
    void Start()
    {
        // Set lifetime
        Destroy(gameObject, 10f);

        // Set initial speed
        rigidBody.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Asteroid"))
            Destroy(gameObject);
    }
}
