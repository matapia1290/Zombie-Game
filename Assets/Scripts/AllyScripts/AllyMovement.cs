using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AllyMovement : MonoBehaviour
{
    public List<Transform> patrolLocation = new List<Transform>();
    public NavMeshAgent ally;
    GameObject player;
    AllyShootLogic allyShootLogic;
    public int patrolIndex = 0;
    public bool followPlayer = false;
    void Awake()
    {
        allyShootLogic = GetComponent<AllyShootLogic>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ally = GetComponent<NavMeshAgent>();
        patrolIndex = Random.Range(0, patrolLocation.Count - 1);
        ally.SetDestination(patrolLocation[patrolIndex].position);
    }
    

    void Update()
    {
        //float playerDistance = Mathf.Abs(gameObject.transform.position.magnitude - player.transform.position.magnitude);
        for (int i = 0; i < allyShootLogic.Zombie.Count; i++) 
        {
            float zombieDistance = Mathf.Abs(gameObject.transform.position.magnitude - allyShootLogic.Zombie[i].transform.position.magnitude);
            if (allyShootLogic.Zombie[i] != null )
            {
                
                if (zombieDistance < 10f)
                {
                    ally.isStopped = true;
                    //Debug.Log("Engaging Zombie");
                }

            }
            Patrol();
            
            

        }
        
        /*
        if (!followPlayer && Input.GetKey(KeyCode.E) && distance <=1f) 
        {
            if (allyShootLogic.Zombie.Count > 0) 
            {
                ally.isStopped = true;
            }
            else 
            {
                ally.isStopped = false;
                Patrol();
            }
        }
        else if (followPlayer && Input.GetKey(KeyCode.E) && distance <= 1f)
        {
            if (allyShootLogic.Zombie.Count > 0)
            {
                ally.isStopped = true;
            }
            else 
            {
                FollowPlayer();
            }
        }
        */
    }
    void Patrol()
    {
        ally.isStopped = false;
        if (ally.remainingDistance > 5f)
        {
            ally.SetDestination(patrolLocation[patrolIndex].position);
        }
        else
        {
            patrolIndex = Random.Range(0, patrolLocation.Count - 1);
            ally.SetDestination(patrolLocation[patrolIndex].position);
        }
    }
    void FollowPlayer() 
    {
        ally.SetDestination(player.transform.position);
        if (ally.remainingDistance <=5f) 
        {
            ally.isStopped = true;
        }
        else 
        {
            ally.isStopped = false;
        }
    }
    void EngageMode() 
    {
        
    }
}
