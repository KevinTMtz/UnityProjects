using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerController : MonoBehaviour
{
    private GameObject s1;
    private GameObject s2;
    private GameObject s3;

    private GameObject greenTank;
    private GameObject blueTank;
    private GameObject blackTank;
    
    // Start is called before the first frame update
    void Start()
    {
        s1 = GameObject.Find("Spawner1");
        s2 = GameObject.Find("Spawner2");
        s3 = GameObject.Find("Spawner3");

        greenTank = (GameObject) Resources.Load("Prefabs/GreenTank", typeof(GameObject));
        blueTank = (GameObject) Resources.Load("Prefabs/BlueTank", typeof(GameObject));
        blackTank = (GameObject) Resources.Load("Prefabs/BlackTank", typeof(GameObject));

        InvokeRepeating("SpawnGreenTank",0,2);
        InvokeRepeating("SpawnBlueTank",0,2.5f);
        InvokeRepeating("SpawnBlackTank",0,3);
    }

    void SpawnGreenTank() {
        Instantiate(greenTank, s1.transform.position, greenTank.transform.rotation);
    }

    void SpawnBlueTank() {
        Instantiate(blueTank, s2.transform.position, blueTank.transform.rotation);
    }

    void SpawnBlackTank() {
        Instantiate(blackTank, s3.transform.position, blackTank.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
