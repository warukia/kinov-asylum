using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Esto es el código del armario para esconderse.

    [SerializeField] private Collider2D coll;
    [SerializeField] private ContactFilter2D contactFilter;
    private List<Collider2D> collidedObjects = new List<Collider2D>(1);

    private void Start()
    {
        animator.SetBool("isOpenedHash", false);
    }

    private void Update()
    {

    }

    public void ActivateAnimation()
    {
        StartCoroutine(OpenAnimation());
    }

    public IEnumerator OpenAnimation()
    {
        animator.SetBool("isOpenedHash", true);
        yield return new WaitForSeconds(.5f);
        animator.SetBool("isOpenedHash", false);
    }
}
