using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;

    public float mouseSens = 2f;
    public float rotateCamx;
    public float rotateCamy;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        VerticalLook();
        HorizontalLook();
    }
    void VerticalLook() 
    {
        float mouseY = Input.GetAxis("Mouse Y");
        rotateCamy += mouseY;

        rotateCamy = Mathf.Clamp(rotateCamy, -70, 90);

        cam.transform.localRotation = Quaternion.Euler(-rotateCamy, 0, 0);
    }

    void HorizontalLook() 
    {
        float mouseX = Input.GetAxis("Mouse X");
        rotateCamx += mouseX;

        player.transform.localRotation = Quaternion.Euler(0, rotateCamx, 0);
    }
}
