using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform finishLine;
    Transform Bot;
    public float maxSpeed;
    public float minSpeed;
    private float speed;
    public float steeringSpeed;
    public float steering;
    bool finished = false;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Delay());
    }
    void FixedUpdate()
    {
        Bot = gameObject.transform;
        if (Bot.position.x < finishLine.position.x)
        {
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, steering * Time.fixedDeltaTime);
        }
        else
        {
            
                speed = 0;
                steering = 0;
                finished = true;
                StopCoroutine(Delay());
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
    }
    IEnumerator Delay()
    {
        while (!finished)
        {
            speed = Random.Range(minSpeed, maxSpeed);
            steering = Random.Range(0, steeringSpeed);
            //Debug.Log("Going Down");
            yield return new WaitForSeconds(Random.Range(1, 5));
            steering = Random.Range(-steeringSpeed, 0);
            speed = Random.Range(minSpeed, maxSpeed);
            // Debug.Log("Going Up");
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Top"))
        {
            steering = -500;
            Debug.Log("Touching Top");
        }

        if (collision.collider.CompareTag("Bottom") && rb.gravityScale != 1)
        {
            steering = 500;
            Debug.Log("Touching Bottom");
        }

        if (collision.collider.CompareTag("Gravity")) 
        {
            StartCoroutine(Gravity());
        }
    }

    IEnumerator Gravity() 
    {
        rb.gravityScale = 1;
        yield return new WaitForSeconds(5);
        rb.gravityScale = 0;
    }
}
