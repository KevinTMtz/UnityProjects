using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject enemyDeath;

    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if ((other.gameObject.tag.Equals("Enemy") && gameController.isPlaying) || other.gameObject.tag.Equals("Danger")) {
            Destroy(gameObject);
            Instantiate(enemyDeath, transform.position, transform.rotation);
        }
    }
}
