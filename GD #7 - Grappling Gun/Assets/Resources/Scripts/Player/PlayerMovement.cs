using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator animator;

    private float xMove;
    public float speed;
    public float jumpForce;

    private bool facingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SoundManager>().StopAllSongs();
        FindObjectOfType<SoundManager>().Play("Rise");
        
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animation();
        Jump();
    }

    private void Movement() {
        xMove = Input.GetAxis("Horizontal");
        Vector2 movementForce = new Vector2(xMove * speed, 0);

        if (!animator.GetBool("Jumping"))
            playerRigidbody.velocity = new Vector2(xMove * speed, playerRigidbody.velocity.y);
        else
            playerRigidbody.AddForce(movementForce);
    }

    private void Jump() {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)) && !animator.GetBool("Jumping")) {
            SoundManager.PlaySound("Jump");
            animator.SetBool("Jumping", true);
            playerRigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Animation() {
        animator.SetFloat("Speed", Mathf.Abs(xMove));
        
        if (facingRight == false && xMove > 0) {
            Flip();
        } else if (facingRight == true && xMove < 0) {
            Flip();
        }
    }

    private void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
}
