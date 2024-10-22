using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento

    public float jumpForce = 10f;     // Fuerza del salto

    public Transform groundCheck;      // Transform para verificar si está en el suelo
    public LayerMask groundLayer;      // Capa que representa el suelo


    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si el jugador está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);

        // Obtener el input horizontal
        float moveInput = Input.GetAxis("Horizontal");

        // Mover al jugador
        Vector3 movement = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0f);
        rb.velocity = movement;

        // Saltar
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(groundCheck.position, 0.1f);
        }
    }
}
