using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveController : MonoBehaviour
{
    private Transform prevParent;

    /*
    private bool moveWithPlatform;
    private Transform otherObject;

    void Update() {
        if (moveWithPlatform) {
            otherObject.position = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        moveWithPlatform = true;
        otherObject = other.gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D other) {
        moveWithPlatform = false;
    }
    */

    private void OnCollisionEnter2D(Collision2D other) {
        prevParent = other.gameObject.transform.parent;
        other.gameObject.transform.parent = gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.gameObject.transform.parent = prevParent;
    }
}
