using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootScript : MonoBehaviour
{
    //Vars to make shooting possible
    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float bulletSpeed = 0;
    //Ammo text to display on UI
    public Text ammoText;
    //Ammo counts
    public int pistolMagCount;
    public int pistolMag;
    public int pistolAmmo;
    public float pistolReloadSpeed;
    private int arMag;
    private int arAmmo;
    private int arMagMax;
    private float arReloadSpeed;
    //Reload bools
    public bool isReloading = false;
    void Start()
    {
        pistolAmmo = pistolMag * pistolMagCount;
    }
    void Update()
    {
        SemiAuto();
    }
    void SemiAuto()
    {
        ammoText.text = pistolMag + "/" + pistolAmmo;
        
        if (pistolMag <= 0) 
        {   
           float timer = 0;
           isReloading = true;
           timer += Time.deltaTime;
           Debug.Log(timer);
           if(timer >= pistolReloadSpeed) 
           {
              timer = 0;
              pistolAmmo -= pistolMag;
              pistolMag += pistolMag;
              isReloading = false;
           }
        }

        if (!isReloading)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pistolMag--;
                GameObject newBullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
                Rigidbody rb = newBullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = bulletPos.forward * bulletSpeed;
                }
            }
        }
    }
}
