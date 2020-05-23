using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject robot1;
    public GameObject[] robot2;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchRobot1", 1, Random.Range(3,6));
        InvokeRepeating("LaunchRobot2AndObstacles", 0, Random.Range(2,5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LaunchRobot1() {
        Instantiate(robot1, new Vector3(transform.position.x, transform.position.y-2), transform.rotation);
    }

    private void LaunchRobot2AndObstacles() {
        Instantiate(robot2[Random.Range(0,robot2.Length)], new Vector3(transform.position.x, Random.Range(-2, 3.8f), transform.position.z), transform.rotation);
    }
}
