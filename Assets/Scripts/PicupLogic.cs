using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicupLogic : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 30f);    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }
}
