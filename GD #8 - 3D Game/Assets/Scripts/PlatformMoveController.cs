using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveController : MonoBehaviour
{
    private Transform prevParent;

    private void OnTriggerEnter(Collider other) {
        prevParent = other.gameObject.transform.parent;
        other.gameObject.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other) {
        other.gameObject.transform.parent = prevParent;
    }
}
