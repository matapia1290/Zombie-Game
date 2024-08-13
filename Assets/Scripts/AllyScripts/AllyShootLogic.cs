using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AllyShootLogic : MonoBehaviour
{
    //Ally stats
    public NavMeshAgent ally;
    Transform allyTransform;
    public float health;

    //Zombie Stats
    GameObject zombie;
    GameObject player;
    Vector3 distance;

    //Gun variables
    public List<GameObject> Zombie = new List<GameObject>(); 
    public Transform shootPosition;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    float bulletTimer = 0;
    public bool shooting = false;

    void Start()
    {
        zombie = GameObject.FindGameObjectWithTag("Zombie");
        allyTransform = gameObject.transform;
        ally = GetComponent<NavMeshAgent>();

    }
    
    // Update is called once per frame
    void Update()
    {
        Health();
        if (Zombie.Count > 0) 
        {
            ClosestZombie();
            Shoot();
        }
    }
    
    void Shoot() 
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer > 1f)
        {
            GameObject newBullet = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = shootPosition.forward * bulletSpeed;
            }

            bulletTimer = 0;
        }
    }

    void ClosestZombie() 
    {
        for (int i = 0; i < Zombie.Count; i++)
        {
            if (Zombie[i] != null) 
            {
                float distance = gameObject.transform.position.magnitude - Zombie[i].transform.position.magnitude;
                //Debug.Log("Distance of: " + distance + " of :" + Zombie[i].name);
                if (distance <= 30f)
                {
                    allyTransform.LookAt(Zombie[i].transform);
                }
                
            }
            else
            {
                Zombie.Remove(Zombie[i]);
            }

        }
    }
   

     void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.CompareTag("Zombie")) 
        {
            if (!Zombie.Contains(other.gameObject)) 
            {
                Zombie.Add(other.gameObject);
            }
        }
     }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            if (Zombie.Contains(other.gameObject))
            {
                Zombie.Remove(other.gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Zombie")) 
        {
            health -= Random.Range(20,30);
        }
    }
    void Health() 
    {
        if (health <=0) 
        {
            Destroy(gameObject);
        }
    }

}

