using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lady : MonoBehaviour
{
    // Lady no ataca, pero usa a sus esclavos para intentar atacar a Yuliya.
    // Lady invierte los controles cada cierto tiempo
    // Cuando los invierte, aparece una imagen glitcheada en la pantalla que indica el cambio de controles.

    private GameObject playerObject;
    private PlayerController playerController;
    private Canvas canvas;
    private Image switchImage;

    void Start()
    {
        playerObject = GameObject.Find("Player").GetComponent<GameObject>();
        playerController = playerObject.GetComponent<PlayerController>();
        canvas = GameObject.Find("Canvas Rooms").GetComponent<Canvas>();
        switchImage = canvas.transform.Find("LadySwitch").GetComponent <Image>();



        StartCoroutine(InvertControllers());
    }

    void Update()
    {
        
    }

    private IEnumerator InvertControllers()
    {
        yield return new WaitForSeconds(5);
        playerController.invertedMovementOn = true;
    }
}