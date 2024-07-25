using System.Collections;
using System.Collections.Generic;
using UnityEngine; 


public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    private float doubleSpeed;
    public float normalSpeed;

    private bool trick = false;
    private bool controlDisable = false;
    void Start()
    {
        doubleSpeed = speed * 2;
        normalSpeed = speed;

        rb = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Speed"))
        {
            StartCoroutine(Speed());
        }

        if (collision.collider.CompareTag("Trick"))
        {
            StartCoroutine(Trick());
        }

        if (collision.collider.CompareTag("Gravity"))
        {
            StartCoroutine(Gravity());
        }

        if (collision.collider.CompareTag("Controls"))
        {
            controlDisable = true;
        }

    }
    private void FixedUpdate()
    {
        if (!trick) 
        {
             rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.fixedDeltaTime;
        }
        else if (trick) 
        {
            rb.velocity = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"))  * -speed * Time.fixedDeltaTime;
        }
        
        if (controlDisable) 
        {
            StartCoroutine(Disable());
        }
             
    }
    
    IEnumerator Trick() 
    {
        trick = true;
        yield return new WaitForSeconds(5);
        trick = false;

    }
    IEnumerator Speed() 
    {
        speed = doubleSpeed;
        yield return new WaitForSeconds(5);
        speed = normalSpeed;
    }

    IEnumerator Gravity() 
    {
        rb.gravityScale = 1;
        yield return new WaitForSeconds(5);
        rb.gravityScale = 0;
    }

    IEnumerator Disable() 
    {
        rb.velocity = new Vector2(0, speed * Time.deltaTime);
        yield return  new WaitForSeconds(5);
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.fixedDeltaTime;
    }

}
