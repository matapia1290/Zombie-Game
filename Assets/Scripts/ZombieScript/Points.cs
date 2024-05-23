using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public List<GameObject> Zombie = new List<GameObject>();
    public int points = 0;
    void Update()
    {
       
        for (int i= 0; i < Zombie.Count;i++) 
        {
            if(Zombie[i] == null) 
            {
                Zombie.RemoveAt(i);
                points++;
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Zombie")) 
        {
            Zombie.Add(other.gameObject);
        }
    }

}
