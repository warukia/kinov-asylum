using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakSoundController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public AudioClip[] leakDropClip;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeakDrop"))
        {
            audioSource.PlayOneShot(leakDropClip[Random.Range(0, 3)], .7f);
        }
    }
}