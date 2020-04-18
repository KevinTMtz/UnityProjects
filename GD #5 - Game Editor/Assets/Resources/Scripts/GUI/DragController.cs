using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private bool isDragging;

    private GameController gameController;

    private BoxCollider2D bc2D;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging && !gameController.isPlaying) {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
            gameObject.transform.Translate(mouseWorldPosition);
        }
    }

    void OnMouseDown() {
        isDragging = true;
    }

    void OnMouseUp() {
        isDragging = false;
    }
}
