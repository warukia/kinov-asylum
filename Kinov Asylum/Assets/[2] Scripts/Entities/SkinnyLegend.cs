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
    public SkinnyLegendActivation skinnyLegendActivation;

    private int secondsActivation = 2;
    private float speed = 5.1f;
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
        audioSource.PlayOneShot(SLShoutingClip, .7f);
        animator.SetBool("isScreaming", true);

        // Comienzo de la run

        yield return new WaitForSeconds(secondsActivation);

        animator.SetBool("isScreaming", false);
        rb.velocity = new Vector2(speed, 0);
    }
}