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
            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        isExploding = false;
        animator.SetBool("explode", true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
