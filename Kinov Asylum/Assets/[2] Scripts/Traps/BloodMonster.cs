using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMonster : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        StartCoroutine(Attack());
    }

    void Update()
    {

    }

    private IEnumerator Attack()
    {
        float secondsAttack = Random.Range(1.5f, 4f);
        yield return new WaitForSeconds(secondsAttack);
        animator.SetBool("attack", true);

        yield return new WaitForSeconds(.5f);
        animator.SetBool("attack", false);

        StartCoroutine(Attack());
    }
}
