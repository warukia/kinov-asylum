using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;

    // MOVIMIENTO
    public float jumpSpeed = 8f;
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    public float stamina = 10f;
    private float horizontal;
    private bool isFacingRight = true;
    private bool isHiding = false;

    // VIDA
    public float health = 100f;

    void Start()
    {

    }

    void Update()
    {
        // Movimiento y salto del personaje.
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * .8f);
        }
    }

    private void FixedUpdate()
    {
        // Movimiento del personaje.
        rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        // Cuando está en colisión con el suelo nos permite saltar.
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // Voltea el sprite dependiendo de la direccion en la cual esté mirando.
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hide"))
        {
            if  (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("si");
            }
        }
    }
}
