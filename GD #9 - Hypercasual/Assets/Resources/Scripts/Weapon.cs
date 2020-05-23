using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform firePoint;
    public GameObject bulletPrefab; 

    private bool wait;
    public float waitTime;

    void Start() {
        firePoint = GameObject.Find("ShootPoint").transform;
        wait = true;
    }
    
    // Update is called once per frame
    void Update()
    {    
        if (Input.GetButtonDown("Fire1") && wait) {
            Shoot();
        }
    }

    void Shoot() {
        // Shooting Logic
        GameObject tempBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StartCoroutine(waitToShoot());
    }

    IEnumerator waitToShoot() {
        wait = false;
        yield return new WaitForSeconds(waitTime);
        wait = true;
    }
}