using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinnyLegend : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    public AudioClip SLShoutingClip;
    public AudioClip SLBonesChasingClip;
    public SkinnyLegendActivation skinnyLegendActivation;

    private float speed = 4.88f;
    public bool IsActive = false;

    void Update()
    {
        // Activación de la run
        if (IsActive)
        {
            StartCoroutine(Activation());
        }
    }

    private IEnumerator Activation() // Saldrá de la pared.
    {
        // Aparición de Skinny Legend
        IsActive = false;
        rb.velocity = new Vector2(70, 0);
        audioSource.PlayOneShot(SLShoutingClip, .7f);
        animator.SetBool("isScreaming", true);

        yield return new WaitForSeconds(.1f);
        rb.velocity = new Vector2(.5f, 0);

        // Comienzo de la run

        yield return new WaitForSeconds(1.8f);

        animator.SetBool("isScreaming", false);
        audioSource.PlayOneShot(SLBonesChasingClip, 1);
        rb.velocity = new Vector2(speed, 0);
    }
}