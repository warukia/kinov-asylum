using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    BoxCollider2D coll;
    public PlayerInputActions playerControls;

    //Vector2 moveDirection = Vector2.zero;
    public float jumpSpeed = 7f;
    float walkSpeed = 5f;
    float runSpeed = 8f;
    float stamina = 10f;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 dirX = playerControls.ReadValue<Vector2>();
        rb.velocity = new Vector2(dirX.x * walkSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }


}
