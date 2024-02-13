using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;
using TMPro;

public enum PlayerStates { Locomotion, Closet, Dialogue, Death, CantMoveSL, InvertedLocomotion };
/* Sirve para enumerar diferentes estados de un personaje. Por ejemplo a un policia, se le pueden poner
   diferentes estados como patrullar, perseguir negros, y disparar. De esta manera podremos cambiar de
   estado m�s f�cilmente y nos ahorraremos bastantes booleanos.
*/

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Animator animator;
    public GameController gameController;
    public RoomCounter roomController;

    private PlayerStates currentPlayerState;

    // VIDA
    public float damageTaken;
    private static float health = 100f;
    public TextMeshProUGUI HealthTextUI;
    private Canvas canvas;


    // MOVIMIENTO
    public float jumpSpeed = 8f;
    public float walkSpeed = 2f;
    public float runSpeed = 7f;
    private float horizontal;
    private bool running = false;
    private bool isFacingRight = true;

    // LADY: movimiento invertido
    public bool invertedMovementOn = false;

    // MOVIMIENTO ENTRE ROOMS
    private GameObject door;
    private RoomCounter roomCounter;



    // STAMINA
    public Image StaminaBar;
    public float Stamina = 100f;
    public float MaxStamina = 100f;
    public float RunCost = 50f;
    public float ChargeRate = 33f;
    private Coroutine recharge;

    // ESCONDERSE EN ARMARIO
    private bool CanHide = false;


    // OTROS
    private static bool CanGoBack;
    private bool SLActivate = false;


    void Start()
    {
        currentPlayerState = PlayerStates.Locomotion;

        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        canvas = GameObject.Find("Canvas Rooms").GetComponent<Canvas>();
        HealthTextUI = canvas.transform.Find("Health").GetComponent<TextMeshProUGUI>();
        StaminaBar = canvas.transform.Find("Stamina Bar/Stamina").GetComponent<Image>();

        //door = GameObject.Find("Door");
        //roomCounter = door.GetComponent<RoomCounter>();
        roomCounter = GameObject.Find("GameController").GetComponent<RoomCounter>();
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
        if (horizontal != 0)
        {
            animator.SetBool("isWalkingHash", true);

            if (running && (horizontal != 0 || Input.GetAxisRaw("Vertical") != 0))
            {
                animator.SetBool("isRunningHash", true);
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
                animator.SetBool("isRunningHash", false);
                rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);
            animator.SetBool("isWalkingHash", false);
            animator.SetBool("isRunningHash", false);
        }

        // LADY inverted controllers
        if (invertedMovementOn)
        {
            currentPlayerState = PlayerStates.InvertedLocomotion;
        }

        // ARMARIO
        if (CanHide && (Input.GetKeyDown(KeyCode.E)))
        {
            // Transici�n de moverse a esconderse en armario.
            rb.velocity = Vector2.zero;
            spriteRenderer.enabled = false;
            currentPlayerState = PlayerStates.Closet;
        }

        // MUERTE
        if (health == 0)
        {
            animator.SetBool("Die", true);
            rb.velocity = Vector2.zero;
            currentPlayerState = PlayerStates.Death;
        }

    }

    private void ProcessInvertedLocomotion()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * -1;
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
        if (horizontal != 0)
        {
            animator.SetBool("isWalkingHash", true);

            if (running && (horizontal != 0 || Input.GetAxisRaw("Vertical") != 0))
            {
                animator.SetBool("isRunningHash", true);
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
                animator.SetBool("isRunningHash", false);
                rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(horizontal * walkSpeed, rb.velocity.y);
            animator.SetBool("isWalkingHash", false);
            animator.SetBool("isRunningHash", false);
        }

        // LADY desactivar inverted movement
        if (!invertedMovementOn)
        {
            currentPlayerState = PlayerStates.Locomotion;
        }

        // MUERTE
        if (health == 0)
        {
            animator.SetBool("Die", true);
            rb.velocity = Vector2.zero;
            currentPlayerState = PlayerStates.Death;
        }
    }

    private void ProcessCloset()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Transici�n de salir del armario.
            spriteRenderer.enabled = true;
            currentPlayerState = PlayerStates.Locomotion;
        }
    }

    private IEnumerator ProcessCantMoveSL()
    {
        // Se queda quieta mientras se reproduce la cinem�tica de Skinny Legend
        currentPlayerState = PlayerStates.CantMoveSL;
        animator.SetBool("isRunningHash", false);
        animator.SetBool("isWalkingHash", false);

        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(5);
        Debug.Log("now you can escape from sl");
        currentPlayerState = PlayerStates.Locomotion;
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

            case PlayerStates.InvertedLocomotion:
                ProcessInvertedLocomotion();
                break;
        }

        HealthTextUI.text = health.ToString();
    }

    private bool IsGrounded()
    {
        // Cuando est� en colisi�n con el suelo nos permite saltar.
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // Voltea el sprite dependiendo de la direccion en la cual est� mirando.
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

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
        // ESCONDERSE EN ARMARIOS
        if (collision.gameObject.CompareTag("Hide"))
        {
            CanHide = true;
        }


        // MOVERSE ENTRE ROOMS
        if (collision.gameObject.CompareTag("Door"))
        {
            // Vuelve a permitir que vaya atr�s
            CanGoBack = true;

            roomCounter.RoomUpdater++;
            roomCounter.CalculateRoomIndex(0);
        }

        if (collision.gameObject.CompareTag("BackDoor") && CanGoBack)
        {
            // No permite que vaya atr�s
            CanGoBack = false;

            roomCounter.RoomUpdater--;
            roomCounter.CalculateRoomIndex(1);
        }

        // POULETTE
        if (collision.gameObject.CompareTag("Poulette") && (currentPlayerState == PlayerStates.Locomotion))
        {
            TakeDamage(100);
        }


        // SKINNY LEGEND
        if (collision.gameObject.CompareTag("Active SL"))
        {
            StartCoroutine(ProcessCantMoveSL());
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hide"))
        {
            CanHide = false;
        }
    }





    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"Took {damage} points of damage and Yuliya's health is {health}.");
    }
}