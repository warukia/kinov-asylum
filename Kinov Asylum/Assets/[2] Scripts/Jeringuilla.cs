using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeringuilla : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprRenderer;
    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator anim;
    public GameObject lightJeringuilla;

    public AudioClip jeringuillaClip;

    void Start()
    {
        sprRenderer.enabled = false;
        coll.enabled = false;
        anim.enabled = false;
        lightJeringuilla.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
