using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);       
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
