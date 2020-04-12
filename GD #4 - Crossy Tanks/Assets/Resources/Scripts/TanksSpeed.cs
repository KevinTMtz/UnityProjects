using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag.Equals("GreenTank")) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (-2, 0, 0);
        } else if (gameObject.tag.Equals("BlueTank")) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (2, 0, 0);
        } else if (gameObject.tag.Equals("BlackTank")) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3 (-2, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            Destroy(gameObject);
        }
    }
}
