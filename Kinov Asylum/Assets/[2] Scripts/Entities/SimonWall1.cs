using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonWall1 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform pos;

    public GameObject simonWall2;
    private float originalPos2;

    private bool hasInverted;
    private bool isWaiting;
    private float originalPos;
    private float limitPos;
    private float speed;

    void Start()
    {
        speed = 2f;
        originalPos = pos.position.x;
        limitPos = 5f;
        hasInverted = false;
        isWaiting = false;
        originalPos2 = simonWall2.GetComponent<Transform>().position.x;

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
            isWaiting = true;
        }

        if (simonWall2.GetComponent<Transform>().position.x >= originalPos2 && isWaiting)
        {
            StartCoroutine(Movement());
            isWaiting = false;
        }
    }

    private IEnumerator Movement()
    {
        yield return new WaitForSeconds(6);
        speed = 2f;
        rb.velocity = new Vector2(speed, 0);
    }
}