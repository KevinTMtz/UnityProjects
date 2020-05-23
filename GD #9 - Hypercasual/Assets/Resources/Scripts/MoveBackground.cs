using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{    
    public float scrollSpeed = -3f;
    private Vector2 startPos = new Vector2(-26.8f,0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() {
        float newPos = Mathf.Repeat (Time.time * scrollSpeed, 26.8f);
        transform.position = startPos + Vector2.right * newPos;
    }
}
