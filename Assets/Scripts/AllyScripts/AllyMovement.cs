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
    public int patrolIndex;
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
        float distance = gameObject.transform.position.magnitude - player.transform.position.magnitude;
        Debug.Log(distance);
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
        
    }
    void Patrol()
    {
       
        if (ally.remainingDistance < 1f) 
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
}
