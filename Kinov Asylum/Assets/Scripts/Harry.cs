using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : MonoBehaviour
{
    // Harry se mueve de un lado a otro haciendo daño

    [SerializeField] private Animator anim;
    public float speed = 8f;

    private float posXActual;
    private float posXA = -3.7f;
    private float posXB = 15.7f;


    void Start()
    {
        // anim.setbool("isrunning", true);
    }

    void Update()
    {
        posXActual = transform.position.x;

        if (posXActual <= posXA || posXActual >= posXB)
        {
            speed *= -1;
        }

    }
}