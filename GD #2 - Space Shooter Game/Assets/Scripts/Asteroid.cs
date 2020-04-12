using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // Set lifetime
        Destroy(gameObject, 15f);

        Vector3 speed = new Vector3(Random.Range(-5f, 5f),Random.Range(-5f, -1f),0);

        // Set initial speed
        rigidBody.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
