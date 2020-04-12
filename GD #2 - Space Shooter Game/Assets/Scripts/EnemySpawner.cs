using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bigEnemy;
    public GameObject enemy;
    public GameObject asteroid;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateBigEnemyShips", 0f, 4f);
        InvokeRepeating("InstantiateEnemyShips", 3f, 8f);
        InvokeRepeating("InstantiateAsteroid", 2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InstantiateBigEnemyShips() {
        Instantiate(bigEnemy, new Vector3(Random.Range(-7.5f, 7.5f),7.5f,0f), Quaternion.identity);
    }

    void InstantiateEnemyShips() {
        Instantiate(enemy, new Vector3(Random.Range(-6.0f, 6.0f),7.5f,0f), Quaternion.identity);
    }

    void InstantiateAsteroid() {
        Instantiate(asteroid, new Vector3(Random.Range(-6.5f, 6.5f),7.5f,0f), Quaternion.identity);
    }
}
