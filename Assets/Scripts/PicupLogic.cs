using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicupLogic : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 30f);    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
