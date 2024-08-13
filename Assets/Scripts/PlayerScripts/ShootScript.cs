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
    private int pistolMag ;
    public int pistolMagMax;
    private int pistolAmmo;
    public float pistolReloadSpeed = 0.9f;
    private int arMag;
    private int arAmmo;
    private int arMagMax;
    private float arReloadSpeed;
    //Reload bools
    public bool rPressed = false;
    public bool isReloading = false;
    public float timer = 0;
    void Start()
    {
        pistolMag = pistolMagMax;
        pistolAmmo = pistolMagMax * pistolMagCount;
        ammoText.text = "Ammo: " + pistolMag + "/" + pistolAmmo;
    }
    void Update()
    {
        SemiAuto();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            pistolAmmo += pistolMagMax;
        }
    }
    void SemiAuto()
    {
        ammoText.text = "Ammo: " + pistolMag + "/" + pistolAmmo;
        if (pistolMag > 0 || pistolAmmo > 0)
        {
            
            if (Input.GetKey(KeyCode.R)) 
            {
                rPressed = true;
            }
           
            if((pistolMag <= 0 || pistolMag < pistolMagMax && rPressed) && pistolAmmo > 0) 
            {
                //Debug.Log(timer); 
                timer += Time.deltaTime;
                if (timer >= pistolReloadSpeed) 
                {   
                    isReloading = false;
                    rPressed = false;
                    int remainingAmmo = Mathf.Max(0,pistolAmmo - (pistolMagMax - pistolMag));
                   // Debug.Log("Ammo Left " + remainingAmmo);
                    pistolMag = Mathf.Min(pistolAmmo + remainingAmmo, pistolMagMax);
                    //Debug.Log("Pistol Mag " + pistolMag);
                    pistolAmmo = remainingAmmo;
                    timer = 0;
                }
            }
            
            if(!isReloading && pistolMag > 0) 
            {
                 if(Input.GetMouseButtonDown(0))
                 {
                    pistolMag--;
                    GameObject newBullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
                    Rigidbody rb = newBullet.GetComponent<Rigidbody>();
                    if(rb != null)
                    {
                        rb.velocity = bulletPos.forward * bulletSpeed;
                    }
                 }
            }
        }
    }
}
