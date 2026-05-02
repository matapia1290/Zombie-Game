using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public int playerHealth;
    public int playerPoints;
    private int playerStamina;
    public GameObject player;
    public GameObject spawner;
    public Text healthText;
    public Text pointsText;
    public Text staminaText;
    ///public Text gameOver;
    MovementScript move;
    ShootScript shoot;
    MouseMovement mouse;
    public Camera mainCamera;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Awake()
    {

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
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        playerStamina = Mathf.FloorToInt(move.staminaMeter);
        healthText.text = "Health: " + playerHealth;
        pointsText.text = "Points: " + playerPoints;
        staminaText.text = "Stamina: " + playerStamina;
      
    }

           

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {

            playerHealth -= Random.Range(1, 5);


        }

        if (collision.gameObject.CompareTag("Health"))
        {
            playerHealth += Random.Range(1, 10);
            if (playerHealth > 100)
            {
                playerHealth = 100;
            }
        }
    }





}