using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Animator itemAni;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player")) {
            itemAni = gameObject.GetComponent<Animator> ();
            itemAni.Play("Touched Gem");
            StartCoroutine(CoroutineToKillObject());
            SoundManager.PlaySound("pu1");
        } 
    }

    IEnumerator CoroutineToKillObject()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("YouWin", LoadSceneMode.Single);
        //Destroy(gameObject);
    }
}
