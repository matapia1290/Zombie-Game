using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieMovement : MonoBehaviour
{
    public List<GameObject> humans = new List<GameObject>();
    public string[] movingAnimation = new string[3];
    public string[] deathAnimation = new string[2];
    public NavMeshAgent zombie;
    public Transform zombPos;
    public int zombieHealth;
    public int lootDropNumber;
    public GameObject healthPack, AmmoPack;
    private GameObject player;
    private Animator zAnim;
    // public Transform player;
    bool dead = false;
    PlayerStats stats;
    void Start()
    {
      
        zAnim = GetComponent<Animator>();
        zAnim.SetTrigger(movingAnimation[Random.Range(0, movingAnimation.Length)]);
        player = GameObject.FindWithTag("Player");
        if (player != null) 
        {
            humans.Add(player);
            stats = player.GetComponent<PlayerStats>();
        }
        zombie = GetComponent<NavMeshAgent>();
        lootDropNumber = Random.Range(1,10);
    }
    IEnumerator DeathAnimation() 
    {
            zombie.enabled = false;
            zAnim.SetTrigger("Dying");
            yield return new WaitForSeconds(3.3f);
            Destroy(gameObject);
            switch (lootDropNumber)
            {
                case 1:
                    Instantiate(healthPack, transform.position + Vector3.up * 3, transform.rotation);
                    break;
                case 2:
                    Instantiate(AmmoPack, transform.position + Vector3.up * 3, transform.rotation);
                    break;
            }
            stats.playerPoints++;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        //ZombieRoam();
        ChooseToChase();
        RemoveNull();
        if (1  > zombieHealth) 
        {
            dead = true;
            StartCoroutine(DeathAnimation());
        }
            
    }
    void RemoveNull() 
    {
        if (humans.Count <= 0) return;
        for (int i = 0; i < humans.Count; i++) 
        {
            if (humans[i] == null) humans.Remove(humans[i]);
        }
    }
    void ChooseToChase() 
    {

        if (humans.Count <= 0) return;
        for (int i = 0; i < humans.Count;i++) 
        {
            if (humans[i] != null) 
            {
                float distance = Vector3.Distance(transform.position, humans[i].transform.position);

                if (distance <= 50f)
                {
                    zombie.SetDestination(humans[i].transform.position);
                }
            }

        }
    }

}
