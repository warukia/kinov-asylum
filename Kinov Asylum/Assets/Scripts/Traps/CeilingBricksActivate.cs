using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingBricksActivate : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    public bool IsActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsActive = true;
            Destroy(boxCollider);
        }
    }
}
