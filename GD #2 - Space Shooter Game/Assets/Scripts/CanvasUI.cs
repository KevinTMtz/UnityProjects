using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{
    public GameObject controls;
    public GameObject name;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(makeControlsInvisible());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator makeControlsInvisible() {
        yield return new WaitForSeconds(7.5f);
        controls.SetActive(false);
        name.SetActive(false);
    }
}
