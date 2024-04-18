using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Poulette : MonoBehaviour
{
    // El flickering de las luces est� incorporado en el Animator.

    [SerializeField] private Transform trns;
    private PlayerController playerController;
    private Transform doorPosX;
    private bool isActive = false;
    private float speed = 20f;
    private int seconds;


    void Start()
    {
        seconds = Random.Range(2, 5);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        doorPosX = GameObject.Find("Door").GetComponent<Transform>();
        StartCoroutine(Appear(seconds));
    }

    void Update()
    {
        if (isActive)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(100, -0.15f), speed * Time.deltaTime);
        }

        if (trns.position.x >= (doorPosX.position.x + 5))
        {
            playerController.pouletteCanAdvance = true;
        }
    }

    private IEnumerator Appear(int seconds)
    {
        Debug.Log($"Poulette will appear in {seconds} seconds.");

        yield return new WaitForSeconds(seconds);

        isActive = true;
    }
}