using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "World") {
            animator.SetBool("Jumping", false);
        }
    }

    // void OnTriggerExit2D(Collider2D col)
    // {
    //     if (col.gameObject.tag == "World") {
    //         animator.SetBool("Jumping", true);
    //     }
    // }
}
