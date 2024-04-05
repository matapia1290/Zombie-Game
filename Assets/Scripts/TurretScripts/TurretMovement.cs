using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public GameObject turretBody;
    public GameObject turretBarrel;
    //public GameObject zombie;


    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float bulletSpeed = 0;
    public float bulletTimer = 0;



    public Transform rayPos;
    public float rayDistance = 10f;
    public int rayCount = 5;
    public float coneAngle = 45f;
    public float reset = 0;
    



    public float turnSpeed = 0f;
    private float rotateDegrees = 0f;
    public float turretAngleFixed = 10f;
    private bool turnR = true;
    public bool scanning = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    

        if (scanning)
        {
            BodyMovement();
        }
        reset += Time.deltaTime;

        if (reset > 5 && scanning == false)
        {
            reset = 0;
            scanning = true;
        }




    }
    void BodyMovement()
    {
        if (scanning)
        {
            if (turnR)
            {
                rotateDegrees += turnSpeed * Time.fixedDeltaTime;
                turretBody.transform.localRotation = Quaternion.Euler(0, rotateDegrees, 0);

                if (rotateDegrees >= turretAngleFixed)
                {
                    turnR = false;
                }

            }
            else if (!turnR)
            {
                rotateDegrees -= turnSpeed * Time.fixedDeltaTime;
                turretBody.transform.localRotation = Quaternion.Euler(0, rotateDegrees, 0);

                if (rotateDegrees <= -turretAngleFixed)
                {
                    turnR = true;
                }

            }

        }
    }
    void ShootEnemy()
    {
        scanning = false;

        turretBody.transform.LookAt(GameObject.Find("Zombie(Clone)").transform);
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

      





;
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie") 
        {
            ShootEnemy();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zombie")
        {
            scanning =true;
        }
    }
    void Ray()
    {
        transform.Rotate(Vector3.up * rayDistance * Time.deltaTime);
        Ray ray = new Ray(rayPos.position, rayPos.forward);
        RaycastHit hit;
        Debug.DrawRay(rayPos.position, ray.direction * rayDistance, Color.green);
        if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.name == "Zombie")
        {
            Debug.Log("Zombie Detected");
            ShootEnemy();

        }
    }

}
