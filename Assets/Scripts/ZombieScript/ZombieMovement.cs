using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class ZombieMovement : MonoBehaviour
{
    public List<GameObject> humans = new List<GameObject>();
    public NavMeshAgent zombie;
    public Transform zombPos;
    public int zombieHealth;
    public int zombPoints = 0;
    public int lootDropNumber;
    public GameObject healthPack, AmmoPack;
    private GameObject player;
    private GameObject ally;
   // public Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        zombie = GetComponent<NavMeshAgent>();
        lootDropNumber = Random.Range(1,10);
    }

    // Update is called once per frame
    void Update()
    {
        //ZombieRoam();
        ChooseToChase();
        if (0 == zombieHealth) 
        { 
            Destroy(gameObject);
            switch(lootDropNumber)
            {
                case 1:
                    Instantiate(healthPack, zombPos.position + Vector3.up, zombPos.rotation);
                break;
                case 2:
                    Instantiate(AmmoPack, zombPos.position + Vector3.up, zombPos.rotation);
                    break;
            }
            zombPoints++;
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet")) 
        {
            zombieHealth -= 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ally") && !humans.Contains(other.gameObject)) 
        {
            humans.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ally"))
        {
            humans.Remove(other.gameObject);
        }
    }
    void ChooseToChase() 
    {
        
        for (int i = 0; i < humans.Count;i++) 
        {
            if (humans[i] != null) 
            {
                float distance = gameObject.transform.position.magnitude - humans[i].transform.position.magnitude;

                if (distance <= 50f)
                {
                    zombie.SetDestination(humans[i].transform.position);
                }
            }
            else 
            {
                humans.Remove(humans[i]);
            }

            
            
        }
    }
    

}
