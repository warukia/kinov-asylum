using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chillmeister : MonoBehaviour
{
    [SerializeField] private GameObject canvasDialogues;
    public SpriteRenderer keyE;

    void Start()
    {
        keyE.enabled = false;
    }

    void Update()
    {
        if (keyE.enabled && Input.GetKeyDown(KeyCode.E))
        {
            canvasDialogues.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) keyE.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) keyE.enabled = false;
    }
}
