using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChickens : MonoBehaviour
{
    private GameController gameController;
    private bool alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player") && alive == true) {
            alive = false;
            gameController.KillChicken();
            Destroy(gameObject);
        }
    }
}
