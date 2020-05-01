using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    private Transform player;

    public int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        transform.position = Vector3.Lerp(transform.position, player.position, (Time.deltaTime * speed) / distance);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag.Equals("Player")) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player")) {
            Destroy(gameObject);
        }
    }
}
