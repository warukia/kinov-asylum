using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinnyLegendActivation : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] AudioSource audioSource;
    public SkinnyLegend skinnyLegendScript;
    public AudioClip slThemeClip;
    public BoxCollider2D leftWallCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skinnyLegendScript.IsActive = true;
            Destroy(leftWallCollider);
            Destroy(boxCollider);
            audioSource.PlayOneShot(slThemeClip, 1f);
        }
    }

}