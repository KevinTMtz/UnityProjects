using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xMove;
    private float speed;
    private float jumpForce;

    private bool facingRight;

    private Rigidbody2D playerRigidbody;

    private Animator animator;

    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        speed = 10f;
        jumpForce = 7.5f;
        facingRight = true;

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.isPlaying) {
            xMove = Input.GetAxis("Horizontal");
            playerRigidbody.velocity = new Vector2(xMove * speed, playerRigidbody.velocity.y);

            Animation();
            PlayerJump();
        }
    }

    private void Animation() {
        animator.SetFloat("speed", Mathf.Abs(xMove));
        
        if (facingRight == false && xMove > 0) {
            Flip();
        } else if (facingRight == true && xMove < 0) {
            Flip();
        }
    }

    private void PlayerJump() {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)) && !animator.GetBool("jumping")) {
            animator.SetBool("jumping", true);
            playerRigidbody.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
}
