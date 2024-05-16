using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lady : MonoBehaviour
{
    // Lady no ataca, pero usa a sus esclavos para intentar atacar a Yuliya.
    // Lady invierte los controles cada cierto tiempo
    // Lady controla cuando atacan los hermanos Harry
    // Cuando los invierte, aparece una imagen glitcheada en la pantalla que indica el cambio de controles.

    private GameObject playerObject;
    private PlayerController playerController;
    private Canvas canvas;
    private Image switchImage;
    public Harry harryController;

    void Start()
    {
        playerObject = GameObject.Find("Player");
        playerController = playerObject.GetComponent<PlayerController>();
        harryController = GameObject.Find("Harry_N1").GetComponent<Harry>();
        canvas = GameObject.Find("Canvas Rooms").GetComponent<Canvas>();
        switchImage = canvas.transform.Find("Switch").GetComponent <Image>();
        switchImage.enabled = false;


        StartCoroutine(Level());
    }

    void Update()
    {
        
    }

    // Hay que añadir que se active el movimiento de Harry al iniciar el juego bueno un poco mas tarde y al finalizar.
    private IEnumerator Level()
    {
        yield return new WaitForSeconds(2);
        harryController.allowedMovement = true;
        Debug.Log("Lady's level Started!");

        yield return new WaitForSeconds(5);
        playerController.invertedMovementOn = true;
        switchImage.enabled = true;

        yield return new WaitForSeconds(.3f);
        switchImage.enabled = false;

        yield return new WaitForSeconds(5);
        playerController.invertedMovementOn = false;
        switchImage.enabled = true;

        yield return new WaitForSeconds(.3f);
        switchImage.enabled = false;

        yield return new WaitForSeconds(4);
        playerController.invertedMovementOn = true;
        switchImage.enabled = true;

        yield return new WaitForSeconds(.3f);
        switchImage.enabled = false;

        yield return new WaitForSeconds(5);
        playerController.invertedMovementOn = false;
        switchImage.enabled = true;

        yield return new WaitForSeconds(.3f);
        switchImage.enabled = false;

        //yield return new WaitForSeconds(4);
        //playerController.invertedMovementOn = true;
        //switchImage.enabled = true;

        //yield return new WaitForSeconds(.3f);
        //switchImage.enabled = false;

        //yield return new WaitForSeconds(5);
        //playerController.invertedMovementOn = false;
        //switchImage.enabled = true;

        yield return new WaitForSeconds(.3f);
        switchImage.enabled = false;

        yield return new WaitForSeconds(4);
        Debug.Log("Game ended");
        playerController.ladyCanAdvance = true;
        harryController.allowedMovement = false;
    }
}