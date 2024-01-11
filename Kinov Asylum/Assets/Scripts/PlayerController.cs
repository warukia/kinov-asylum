using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    public GameController gameController;

    // MOVIMIENTO
    public float jumpSpeed = 8f;
    public float walkSpeed = 3f;
    public float runSpeed = 8f;
    private float horizontal;
    private bool running = false;
    private bool isFacingRight = true;
    //private bool isHiding = false;

    // STAMINA
    public Image StaminaBar;
    public float Stamina = 100f;
    public float MaxStamina = 100f;
    public float RunCost = 25f;
    public float ChargeRate = 25f;
    private Coroutine recharge;

    // VIDA
    public float health = 100f;

    // SKINNY LEGEND
    private GameObject SkinnyLegend;
    private SkinnyLegend SkinnyLegendScript;

    void Start()
    {
        SkinnyLegend = GameObject.FindWithTag("SL");
        SkinnyLegendScript = SkinnyLegend.GetComponent<SkinnyLegend>();
    }

    void Update()
    {
        // Movimiento y salto del personaje.
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        // Sprint con Shift
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
            Debug.Log("wazaaaaaaaa");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * .8f);
        }

        // Movimiento del personaje (caminar y esprintar).
        if (running && (horizontal != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
            Stamina -= RunCost * Time.deltaTime;
            if (Stamina < 0) Stamina = 0;
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if (recharge != null)
            {
                StopCoroutine(recharge);
            }
            recharge = StartCoroutine(RechargeStamina());
        }
        else
        {
            rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);
        }

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

    // Recarga la estamina
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1);

        while (Stamina < MaxStamina)
        {
            Stamina += ChargeRate / 10f;
            if (Stamina > MaxStamina)
            {
                Stamina = MaxStamina;
            }
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hide"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("si");
            }
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            gameController.GetComponent<GameController>().LoadNextRoom();
        }

        if (collision.gameObject.CompareTag("Drawer"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("cajon abierto");
            }
        }

        if (collision.gameObject.CompareTag("Active SL"))
        {
            SkinnyLegendScript.IsActive = true;
        }
    }
}