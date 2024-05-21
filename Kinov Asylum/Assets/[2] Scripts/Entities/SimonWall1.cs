using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonWall1 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform pos;

    private bool hasInverted;
    private float originalPos;
    private float limitPos;
    private float speed;

    void Start()
    {
        speed = 1.5f;
        originalPos = pos.position.x;
        limitPos = 5f;
        hasInverted = false;

        rb.velocity = Vector2.zero;
        StartCoroutine(Movement());
    }

    void Update()
    {
        if (pos.position.x >= limitPos && !hasInverted)
        {
            hasInverted = true;
            speed *= -1;
            rb.velocity = new Vector2(speed, 0);
        }

        if (pos.position.x <= originalPos && hasInverted)
        {
            rb.velocity = Vector2.zero;
            hasInverted = false;
            StartCoroutine(Movement());
        }
    }

    private IEnumerator Movement()
    {
        yield return new WaitForSeconds(10);
        speed = 1.5f;
        rb.velocity = new Vector2(speed, 0);
    }
}