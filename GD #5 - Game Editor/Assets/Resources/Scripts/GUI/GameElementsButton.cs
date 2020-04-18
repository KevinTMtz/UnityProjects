using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElementsButton : MonoBehaviour
{   
    private bool puttingObject;

    private GameObject activeGameObject;

    public GameObject elementsPanel;
    public GameObject buttonsPanel;

    private bool waitTime;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (puttingObject) {
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.z = 0;
            activeGameObject.transform.position = pos;
        }

        if (Input.GetButtonDown("Fire1") && puttingObject == true && waitTime) {
            puttingObject = false;
            elementsPanel.SetActive(true);
            buttonsPanel.SetActive(true);
            waitTime = false;
        }
    }

    IEnumerator StartWaitTime() {
        yield return new WaitForSecondsRealtime(0.5f);
        waitTime = true;
    }

    public void InstantiateElement(string elementToInstantiate) {
        elementsPanel.SetActive(false);
        buttonsPanel.SetActive(false);

        activeGameObject = Instantiate(Resources.Load("Prefabs/"+elementToInstantiate, typeof(GameObject))) as GameObject;
        activeGameObject.transform.SetParent(GameObject.Find("- Game Elements -").transform);

        puttingObject = true;
        StartCoroutine(StartWaitTime());
    }

    public void Instantiate1() {
        InstantiateElement("Player");
    }

    public void Instantiate2() {
        InstantiateElement("Enemy");
    }

    public void Instantiate3() {
        InstantiateElement("PingPongPlatform");
    }

    public void Instantiate4() {
        InstantiateElement("StaticPlatform");
    }

    public void Instantiate5() {
        InstantiateElement("SpecialBlock");
    }
}
