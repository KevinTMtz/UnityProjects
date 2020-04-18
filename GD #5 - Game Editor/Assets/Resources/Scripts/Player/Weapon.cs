using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform firePoint;
    public GameObject bulletPrefab; 


    private GameController gameController;

    void Start() {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        firePoint = gameObject.transform;
        
        if (Input.GetButtonDown("Fire1") && gameController.isPlaying) {
            Shoot();
        }
    }

    void Shoot() {
        // Shooting Logic
        GameObject tempBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        tempBullet.transform.SetParent(GameObject.Find("- Bullets -").transform);
    }
}
