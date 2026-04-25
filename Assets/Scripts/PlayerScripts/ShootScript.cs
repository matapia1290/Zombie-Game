using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootScript : MonoBehaviour
{
    //Melee
    public float meleeRange;
    //Line render
    LineRenderer lineRenderer;
    //Ammo text to display on UI
    public Text ammoText;
    //Ammo counts
    public int pistolMagCount;
    private int pistolMag ;
    public int pistolMagMax;
    private int pistolAmmo;
    public float pistolReloadSpeed = 0.9f;
    //Reload bools
    public bool rPressed = false;
    public bool isReloading = false;
    public float timer = 0;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        
        pistolMag = pistolMagMax;
        pistolAmmo = pistolMagMax * pistolMagCount;
        ammoText.text = "Ammo: " + pistolMag + "/" + pistolAmmo;
    }
    void Update()
    {
        SemiAuto();
        Melee();
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
                        Shoot();
                    
                 }
            }
        }
    }

    void Melee() 
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;


            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, meleeRange))
            {
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, Camera.main.transform.position + Camera.main.transform.forward + new Vector3(0, -0.3f, 0f));
                lineRenderer.SetPosition(1, hit.point);

                ZombieMovement enemy = hit.collider.GetComponent<ZombieMovement>();
                if (enemy != null)
                {
                    Debug.Log("Melee'd: " + hit.collider.name);
                    enemy.zombieHealth--;

                }
            }
        }
       
    }
    void Shoot()
    {
        // Calculate the center of the camera viewport
        Vector3 rayOrigin = Camera.main.transform.position;
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit,Mathf.Infinity))
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, Camera.main.transform.position + Camera.main.transform.forward + new Vector3(0,-0.3f,0f));
            lineRenderer.SetPosition(1, hit.point);
            StartCoroutine(LineSpawner());
            // Attempt to get a health component on the hit object
            ZombieMovement enemy = hit.collider.GetComponent<ZombieMovement>();
            if (enemy != null)
            {
                Debug.Log("Shot: " + hit.collider.name);
                enemy.zombieHealth--;
               
            }
        }
    }

    IEnumerator LineSpawner() 
    {
       
        
        yield return new WaitForSeconds(2f);

        lineRenderer.enabled = false;
    }
}
