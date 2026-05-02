using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterScript : MonoBehaviour
{
    [SerializeField]
    private Transform topRotor;
    [SerializeField]
    private Transform bottomRotor;
    [SerializeField]
    private float rotorSpeed;
    void Update()
    {

        topRotor.Rotate(Vector3.up,rotorSpeed * Time.deltaTime);
        bottomRotor.Rotate(Vector3.right, rotorSpeed * Time.deltaTime);
    }
}
