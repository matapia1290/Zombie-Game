using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    //Take the shoot script from the turret and then add an input of left click to shoot.
    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float bulletSpeed = 0;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
           GameObject newBullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
           Rigidbody rb = newBullet.GetComponent<Rigidbody>();
           if (rb != null)
           {
             rb.velocity = bulletPos.forward * bulletSpeed;
           }
        }
    }
}
