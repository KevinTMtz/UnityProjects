using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchItem : MonoBehaviour
{
    public Animator itemAni;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            itemAni = gameObject.GetComponent<Animator> ();
            itemAni.Play("Touched Gem");

            StartCoroutine(CoroutineToKillObject());

            SoundManager.PlaySound("c1");
        }
    }

    IEnumerator CoroutineToKillObject()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
