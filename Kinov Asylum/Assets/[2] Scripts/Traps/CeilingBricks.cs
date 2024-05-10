using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingBricks : MonoBehaviour
{
    [SerializeField] Collider2D col;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;
   
    public CeilingBricksActivate ceilingBricksActivate;

    private float floorPos = -3f;
    public AudioClip ceilingFallClip;


    void Start()
    {
        ceilingBricksActivate = gameObject.transform.GetChild(0).GetComponent<CeilingBricksActivate>();
    }

    void Update()
    {
        if (ceilingBricksActivate.IsActive)
        {
            animator.SetBool("isFalling", true);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(ceilingFallClip, 2f);
            }
            ceilingBricksActivate.IsActive = false;
        }

        if (transform.position.y <= floorPos)
        {
            //ceilingBricksActivate.IsActive = false;
            animator.SetBool("isOnFloor", true);
            Destroy(col);
        }
    }
}
