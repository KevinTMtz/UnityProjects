using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlock : MonoBehaviour
{
    public GameObject enemyDeath;

    public GameObject enemy;
    public GameObject goodItem;
    public GameObject badItem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Bullet")) {
            Destroy(gameObject);
            Instantiate(enemyDeath, transform.position, transform.rotation);

            int tempRandom = Random.Range(0, 3);

            GameObject newGameObject;
            Transform parent = GameObject.Find("- Game Elements -").transform;
            if (tempRandom == 0) {
                newGameObject = Instantiate(enemy, transform.position, transform.rotation);
                newGameObject.transform.SetParent(parent);
            } else if (tempRandom == 1) {
                newGameObject = Instantiate(goodItem, transform.position, transform.rotation);
                newGameObject.transform.SetParent(parent);
            } else {
                newGameObject = Instantiate(badItem, transform.position, transform.rotation);
                newGameObject.transform.SetParent(parent);
            }
        }
    }
}
