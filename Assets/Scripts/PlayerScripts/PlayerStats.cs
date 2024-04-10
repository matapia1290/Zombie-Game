using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int points;
    public Text healthText;
    public Text pointsText;

    void Start()
    {
        healthText.text = "Health: " + health;
        pointsText.text = "Points: " + points;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        pointsText.text = "Points: " + points;
    }
}
