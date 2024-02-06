using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomCounter : MonoBehaviour
{
    public GameController gameController;

    // DETECTAR PUERTA
    private GameObject DoorObject;
    private GameObject BackDoor;

    // N�MERO DE ROOM
    private int numA = 3;
    private int numB = 7;
    public float RoomUpdater; // Float que actualiza la room

    // UI
    private Canvas canvas;
    public TextMeshProUGUI RoomNumberTextUI;
    private static float RoomNumber; // N�mero room actual (el que aparece en la UI)


    // �NDICES DE LAS ROOMS
    public static int indiceRoomActual;
    public static int indiceRoomAnterior;
    public int indiceRoomSiguiente;

    public static bool isInActualRoom;

    void Start()
    {
        // Obtiene el GameController para poder llamar al m�todo
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        // UI
        if (GameObject.Find("Canvas") != null)
        {
            canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            RoomNumberTextUI = canvas.transform.Find("Room number").GetComponent<TextMeshProUGUI>();
            RoomUpdater = RoomNumber;
        }

        // Guarda el �ndice actual y la room anterior cuando avanza
        // SOLO si cuando avanza isInActualRoom = true.

        //if (isInActualRoom)
        //{
        //    indiceRoomAnterior = indiceRoomActual;
        //    indiceRoomActual = SceneManager.GetActiveScene().buildIndex;
        //}
    }

    public void CalculateRoomIndex(int num)
    {
        if (num == 0) // AVANZAR
        {
            if (isInActualRoom)
            {
                do
                {
                    indiceRoomSiguiente = UnityEngine.Random.Range(numA, numB);
                }
                while (indiceRoomSiguiente == indiceRoomActual || indiceRoomSiguiente == indiceRoomAnterior);

                indiceRoomAnterior = SceneManager.GetActiveScene().buildIndex;
                indiceRoomActual = indiceRoomSiguiente;

                Debug.Log("Anterior" + indiceRoomAnterior + " Siguiente " + indiceRoomSiguiente);

                gameController.LoadNextRoom(indiceRoomSiguiente);
            }
            else
            {
                isInActualRoom = true;
                gameController.LoadNextRoom(indiceRoomActual);
            }
        }
        else if (num == 1) // RETROCEDER
        {
            isInActualRoom = false;
            gameController.LoadNextRoom(indiceRoomAnterior);
        }

    }

    void Update()
    {
        // UI
        RoomNumber = RoomUpdater;

        if (RoomNumberTextUI != null)
        {
            RoomNumberTextUI.text = "Room " + RoomNumber.ToString();
        }


    }
}