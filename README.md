using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeaderBoards : MonoBehaviour
{
    public List<GameObject> Finishers = new List<GameObject>();
    void Update()
    {
        for (int i = 0; Finishers.Count > i; i++) 
        {
            
            int placement = i + 1;
            switch (placement) 
            {
                case 1:
                    Debug.Log("First Place: " + Finishers[i]);
                    break;
                case 2:
                    Debug.Log("Second Place: " + Finishers[i]);
                    break;
                case 3:
                    Debug.Log("Third Place: " + Finishers[i]);
                    break;
            }
             

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Finishers.Add(collision.gameObject);
        }
        
    }
}
