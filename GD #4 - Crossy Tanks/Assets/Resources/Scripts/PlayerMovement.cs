using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform playerSpawn;

    private Transform sensorUp;
    private Transform sensorDown;
    private Transform sensorRight;
    private Transform sensorLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        playerSpawn = GameObject.Find("PlayerSpawner").GetComponent<Transform>();

        sensorUp = GameObject.Find("RaycastUp").GetComponent<Transform>();
        sensorDown = GameObject.Find("RaycastDown").GetComponent<Transform>();
        sensorRight = GameObject.Find("RaycastRight").GetComponent<Transform>();
        sensorLeft = GameObject.Find("RaycastLeft").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(sensorUp.position, Vector2.up, 0.5f);
        RaycastHit2D hitDown = Physics2D.Raycast(sensorDown.position, Vector2.down, 0.5f);
        RaycastHit2D hitRight = Physics2D.Raycast(sensorRight.position, Vector2.right, 0.5f);
        RaycastHit2D hitLeft = Physics2D.Raycast(sensorLeft.position, Vector2.left, 0.5f);
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && transform.position.y < 4.5 && (hitUp.collider == null || (hitUp.collider != null && !hitUp.collider.gameObject.name.Equals("Trees"))))
                transform.position += new Vector3 (0, 1, 0);
            
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && (transform.position.y > -4.5) && (hitDown.collider == null || (hitDown.collider != null && !hitDown.collider.gameObject.name.Equals("Trees"))))
            transform.position += new Vector3 (0, -1, 0);
        
        
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && transform.position.x < 8.5 && (hitRight.collider == null || (hitRight.collider != null && !hitRight.collider.gameObject.name.Equals("Trees"))))
            transform.position += new Vector3 (1, 0, 0);
            
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && transform.position.x > -8.5 && (hitLeft.collider == null || (hitLeft.collider != null && !hitLeft.collider.gameObject.name.Equals("Trees"))))
            transform.position += new Vector3 (-1, 0, 0);
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag.Equals("GreenTank") || other.gameObject.tag.Equals("BlueTank") || other.gameObject.tag.Equals("BlackTank")) {
            transform.position = playerSpawn.position;
        }
    }
}
