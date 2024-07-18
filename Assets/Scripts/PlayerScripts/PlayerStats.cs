using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int playerHealth;
    private int playerPoints;
    private int playerStamina;
    public GameObject player;
    public GameObject spawner;
    public Text healthText;
    public Text pointsText;
    public Text staminaText;
    public Camera deathCam;
    Points points;
    MovementScript move;
    ShootScript shoot;
    MouseMovement mouse;
    ZombieSpawner zombSpawner;
    public Camera mainCamera;
    public GameObject floor;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        deathCam.enabled = false;
    }
    void Awake()
    {
        zombSpawner = spawner.GetComponent<ZombieSpawner>();
        points = floor.GetComponent<Points>();
        move = player.GetComponent<MovementScript>();
        shoot = player.GetComponent<ShootScript>();
        mouse = player.GetComponent<MouseMovement>();
        
        
    }
   
    void Update()
    {
        if (playerHealth <= 0 || gameObject.transform.position.y < -3f) 
        {
            playerHealth = 0;
            move.enabled = false;
            shoot.enabled = false;
            mouse.enabled = false;
            mainCamera.enabled = false;
            deathCam.enabled = true;
            zombSpawner.enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        playerStamina = Mathf.FloorToInt(move.staminaMeter);
        playerPoints = points.points;
        healthText.text = "Health: " + playerHealth;
        pointsText.text = "Points: " + playerPoints;
        staminaText.text = "Stamina: " + playerStamina;
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("Zombie")) 
        {
            
                playerHealth -= Random.Range(1, 5);
              
                
        }

        if (other.CompareTag("Health"))
        {
            playerHealth += Random.Range(1, 10);
            if (playerHealth > 100) 
            {
                playerHealth = 100;
            }
        }
    }
    
    
    
    

}