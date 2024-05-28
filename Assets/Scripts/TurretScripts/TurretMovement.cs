using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float bulletSpeed = 0;
    public float bulletTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ShootEnemy()
    {

        gameObject.transform.LookAt(GameObject.Find("Zombie(Clone)").transform);
        bulletTimer += Time.deltaTime;
        if (bulletTimer > .5f)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = bulletPos.forward * bulletSpeed;
            }

            bulletTimer = 0;
        }

    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie")) 
        {
            gameObject.transform.LookAt(other.transform.position);
            ShootEnemy();
        }
    }

}
