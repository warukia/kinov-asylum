using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
using TMPro;

public enum PlayerStates { Locomotion, Closet, Dialogue, Death };
/* Sirve para enumerar diferentes estados de un personaje. Por ejemplo a un policia, se le pueden poner
   diferentes estados como patrullar, perseguir negros, y disparar. De esta manera podremos cambiar de
   estado más fácilmente y nos ahorraremos bastantes booleanos.
*/

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    public GameController gameController;

    private PlayerStates currentPlayerState;

    // VIDA
    public float damageTaken;
    private static float health = 100f;
    public TextMeshProUGUI HealthTextUI;
    private Canvas canvas;


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
    public float ChargeRate = 33f;
    private Coroutine recharge;

    // ESCONDERSE EN ARMARIO
    private bool CanHide = false;

    // ABRIR EL CAJÓN
    private bool CanOpenDrawer = false;



    void Start()
    {
        currentPlayerState = PlayerStates.Locomotion;

        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        HealthTextUI = canvas.transform.Find("Health").GetComponent<TextMeshProUGUI>();

    }



    private void ProcessLocomotion()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        // Sprint con Shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && (Stamina > 0))
        {
            running = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }

        if (Stamina <= 0)
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

        // ARMARIO
        if (CanHide && (Input.GetKeyDown(KeyCode.E)))
        {
            // Transición de moverse a esconderse en armario.
            rb.velocity = Vector2.zero;
            spriteRenderer.enabled = false;
            currentPlayerState = PlayerStates.Closet;
        }

        // CAJÓN
        if (CanOpenDrawer && (Input.GetKeyDown(KeyCode.E)))
        {
            Debug.Log("tokando cajosito");
        }

        // MUERTE
        if (health == 0)
        {
            rb.velocity = Vector2.zero;
            currentPlayerState = PlayerStates.Death;
        }
    }


    private void ProcessCloset()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Transición de salir del armario.
            spriteRenderer.enabled = true;
            currentPlayerState = PlayerStates.Locomotion;
        }
    }

    private IEnumerator ProcessDeath()
    {
        int seconds = 2;

        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene("GameOver");
        health = 100f;
        currentPlayerState = PlayerStates.Locomotion;
    }

    void Update()
    {
        switch (currentPlayerState)
        {
            case PlayerStates.Locomotion:
                ProcessLocomotion();
                break;

            case PlayerStates.Closet:
                ProcessCloset();
                break;

            case PlayerStates.Death:
                StartCoroutine(ProcessDeath());
                break;
        }

        HealthTextUI.text = health.ToString();
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
        int seconds = 1;

        if (Stamina > 0)
        {
            seconds = 1;
        }
        else if (Stamina == 0)
        {
            seconds = 2;
        }

        yield return new WaitForSeconds(seconds);

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







    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hide"))
        {
            CanHide = true;
            Debug.Log(CanHide);
        }

        if (collision.gameObject.CompareTag("Drawer"))
        {
            CanOpenDrawer = true;
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            RoomCounter doorScript = collision.GetComponent<RoomCounter>();
            doorScript.RoomUpdater++;
            gameController.GetComponent<GameController>().LoadNextRoom();
        }

        if (collision.gameObject.CompareTag("Poulette") && (currentPlayerState == PlayerStates.Locomotion))
        {
            TakeDamage(100);
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hide"))
        {
            CanHide = false;
        }

        if (collision.gameObject.CompareTag("Drawer"))
        {
            CanOpenDrawer = false;
        }
    }





    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Took {damage} points of damage and Yuliya's health is {health}.");
    }
}