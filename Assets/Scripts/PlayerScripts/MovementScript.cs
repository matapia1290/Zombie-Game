using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody rb;

    public float walkSpeed = 5f;
    public float sprintSpeed = 8.5f;
    public float jumpForce = 300f;
    public float staminaMeter = 100f;

    public bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RegenStamina();

        // Jump
        if (isGrounded && staminaMeter >= 20f && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            staminaMeter -= 10f;
        }
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && staminaMeter > 0;
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        if (isSprinting && (x != 0 || z != 0))
            UseStamina();

        // Build movement vector in world space
        Vector3 move = (transform.right * x + transform.forward * z) * currentSpeed * Time.fixedDeltaTime;

        // Move using physics — respects colliders, no more clipping
        rb.MovePosition(rb.position + move);
    }

    void RegenStamina()
    {
        staminaMeter = Mathf.Min(staminaMeter + Time.deltaTime * 5f, 100f);
    }

    void UseStamina()
    {
        staminaMeter -= Time.deltaTime * 10f;
        if (staminaMeter <= 0f)
            staminaMeter = 0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            isGrounded = false;
    }
}