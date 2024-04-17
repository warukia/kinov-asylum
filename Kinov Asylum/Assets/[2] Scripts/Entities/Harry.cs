using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : MonoBehaviour
{
    // Harry se mueve de un lado a otro haciendo daño

    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 8f;

    private float posXActual;
    private float posXA = -5f;
    private float posXB = 17f;


    void Start()
    {

        // anim.setbool("isrunning", true);
    }

    void Update()
    {
        posXActual = rb.position.x;

        if (posXActual >= posXB)
        {
            speed = -8;
        }
        if (posXActual <= posXA)
        {
            speed = 8;
        }

        rb.velocity = new Vector2(speed, 0);
    }
}