

This is a zombie game to practice unity 3D.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform finishLine;
    Transform Bot;
    public float speed;
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
            Debug.Log("Stopped");
            speed--;
            if(speed < 0) 
            {
                speed = 0;
                steering = 0;
                finished = true;
                StopCoroutine(Delay());
            }
        }
    }
    IEnumerator Delay() 
    {
        while (!finished) 
        {
            steering = Random.Range(0, 50);
            Debug.Log("Going Down");
            yield return new WaitForSeconds(Random.Range(1,5));
            steering = Random.Range(-50,0);
            Debug.Log("Going Up");
            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}
