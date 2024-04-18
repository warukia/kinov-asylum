using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : MonoBehaviour
{
    // Harry se mueve de un lado a otro haciendo daño

    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 8f;
    public bool allowedMovement;

    private float posXActual;
    private float posXA = -7f;
    private float posXB = 21f;


    void Start()
    {
        allowedMovement = false;
        // anim.setbool("isrunning", true);
    }

    void Update()
    {
        // MOVIMIENTO HARRY
        posXActual = rb.position.x;

        if (posXActual >= posXB)
        {
            speed = -8;
        }
        if (posXActual <= posXA)
        {
            speed = 8;
        }

        if (allowedMovement)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else if (!allowedMovement)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}