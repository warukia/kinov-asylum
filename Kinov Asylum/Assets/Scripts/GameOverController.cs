using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public static string enemyKilled;

    // Este script permite identificar el bicho que te ha matado y reproducir
    // un texto dependiendo de lo que te haya matado.

    void Start()
    {
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
    }
}