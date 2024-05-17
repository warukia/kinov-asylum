using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarryDoor : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

    public static bool isExploding;

    void Start()
    {
        
    }

    void Update()
    {
        if (isExploding)
        {
            Explode();
        }
    }

    private void Explode()
    {
        animator.SetBool("explode", true);
    }
}
