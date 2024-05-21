using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public GameObject panelButtons;
    public static string enemyKilled;

    // Este script permite identificar el bicho que te ha matado y reproducir
    // un texto dependiendo de lo que te haya matado.

    void Start()
    {
        spriteRenderer.enabled = true;
        panelButtons.SetActive(false);

        if (enemyKilled == "Poulette")
        {
            animator.SetBool("PouletteDeathHash", true);
        }
        else if (enemyKilled == "Lady")
        {
            animator.SetBool("LadyDeathHash", true);
        }
        else if (enemyKilled == "Traps")
        {
            animator.SetBool("TrapsDeathHash", true);
        }
        else if (enemyKilled == "SL")
        {
            animator.SetBool("SLDeathHash", true);
        }
        else if (enemyKilled == "Simon")
        {
            animator.SetBool("SimonDeathHash", true);
        }
        else if (enemyKilled == "Viktor")
        {
            animator.SetBool("ViktorDeathHash", true);
        }

        StartCoroutine(FinishAnimation());
    }

    private IEnumerator FinishAnimation()
    {
        yield return new WaitForSeconds(9);
        spriteRenderer.enabled = false;

        animator.SetBool("SimonDeathHash", false);
        animator.SetBool("SLDeathHash", false);
        animator.SetBool("TrapsDeathHash", false);
        animator.SetBool("LadyDeathHash", false);
        animator.SetBool("PouletteDeathHash", false);
        animator.SetBool("ViktorDeathHash", false);

        panelButtons.SetActive(true);
    }
}