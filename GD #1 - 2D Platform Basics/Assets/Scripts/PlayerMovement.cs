using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    // Movement Magnitudes
    public float speed;
    public float jumpForce;
    public float xMove;

    private Rigidbody2D rigidBody;

    // State
    private bool facingRight = true;
    
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    
    public bool musicCheck = true;

    public static bool isAlive = true;

    // Start is called before the first frame update
    void Start() {
        extraJumps = extraJumpsValue;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) {
            if (isGrounded == true) {
                extraJumps = extraJumpsValue;
            }
            
            if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)) && extraJumps == 0 && isGrounded == true) {
                animator.SetBool("IsJumping", true);
                rigidBody.velocity = Vector2.up * jumpForce;
                SoundManager.PlaySound("j1");
            } else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)) && extraJumps > 0) {
                animator.SetBool("IsJumping", true);
                rigidBody.velocity = Vector2.up * jumpForce;
                extraJumps--;
                SoundManager.PlaySound("j1");
            }

            xMove = Input.GetAxis("Horizontal");
            rigidBody.velocity = new Vector2(xMove * speed, rigidBody.velocity.y);

            // Animation
            animator.SetFloat("Speed", Math.Abs(xMove));

            if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S)) {
                animator.SetBool("IsKeyDown", true);
            } else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
                animator.SetBool("IsKeyDown", false);
            }

            // Check if flip is needed
            if (facingRight == false && xMove > 0) {
                Flip();
            } else if (facingRight == true && xMove < 0) {
                Flip();
            }

            // Check if is in the ground
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            if (musicCheck) {
                SoundManager.PlaySound("music");
                musicCheck = false;
            }
        } else { //To Block Movement While Dying
            rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            animator.SetBool("IsJumping", false);
            isGrounded = true;
            animator.Play("Player Hurt");
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }

    // Flip character in X
    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag.Equals("Map")) {
            animator.SetBool("IsJumping", false);
        } 
        
        if (other.gameObject.tag.Equals("Enemy")) {
            animator.Play("Player Hurt");
            SoundManager.PlaySound("go1");
            isAlive = false;

            StartCoroutine(CoroutineToRestart());
        }

        if (other.gameObject.tag.Equals("Die Zone")) {
            animator.Play("Player Hurt");
            SoundManager.PlaySound("go1");
            isAlive = false;

            StartCoroutine(CoroutineToRestart());
        } 
    }

    // Delay Level Restart
    IEnumerator CoroutineToRestart()
    {
        yield return new WaitForSeconds(1);
        isAlive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
