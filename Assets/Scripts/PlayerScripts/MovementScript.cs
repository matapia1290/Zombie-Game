using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 0f;
    public float jumpSpeed = 0f;
    public bool isGrounded = true;
    public float staminaMeter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RegenStamina();
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        //Input on change speed
        
        //Input to move forward 
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && staminaMeter > 0) 
            {
                moveSpeed = 8.5f;
                transform.Translate(Vector3.right * x * Time.deltaTime);
                UseStamina();
            }
            else 
            {
                moveSpeed = 5f; ;
                transform.Translate(Vector3.right * x * Time.deltaTime);
                
            }
           
        }
       
        //Input to move sideways 
        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && staminaMeter > 0)
            {
                moveSpeed  = 8.5f;
                transform.Translate(Vector3.forward * z * Time.deltaTime);
                UseStamina();
            }
            else
            {
                moveSpeed = 5f;
                transform.Translate(Vector3.forward * z * Time.deltaTime);
                
            }
            
        }
        
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpSpeed = 300;
                rb.AddForce(Vector3.up * jumpSpeed);
            }
        }
    }
    void RegenStamina() 
    {
        if(staminaMeter < 100) 
        {
            staminaMeter += Time.deltaTime * 5;
            if (staminaMeter>= 100) 
            {
                staminaMeter = 100;
            }
        }
    }
    void UseStamina()
    {
        if (staminaMeter <= 100 && staminaMeter >= 0)
        {
            staminaMeter -= Time.deltaTime * 10;
            if (staminaMeter <= 0)
            {
                moveSpeed = 5f;
                staminaMeter = 0;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Walls"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Walls")) 
        {
            isGrounded = false;
        }
        
    }
}
