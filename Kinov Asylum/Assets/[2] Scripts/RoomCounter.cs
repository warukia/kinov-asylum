using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomCounter : MonoBehaviour
{
    public GameController gameController;
    private Canvas canvas;

    // DETECTAR PUERTA
    private GameObject DoorObject;
    private GameObject BackDoor;

    // UI & ROOMS
    public TextMeshProUGUI RoomNumberTextUI;
    //public int RoomUpdater; // Float que actualiza la room
    public static int RoomNumber; // Número room actual (es el que aparece en la UI)

    // PLAYABLE SCENES BUILD INDEX
    private int numA = 5;
    private int numB = 10;

    // Escenas especiales
    private int indexLady = 2;
    public int roomLady = 5;
    private int indexSL = 3;
    public int roomSL = 10;

    // ÍNDICES DE LAS ROOMS
    public static int indiceRoomActual;
    public static int indiceRoomAnterior;
    public int indiceRoomSiguiente;

    public static bool isInActualRoom;

    void Start() // Obtiene los componentes necesarios al empezar la room 
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        // UI
        if (GameObject.Find("Canvas Rooms") != null)
        {
            canvas = GameObject.Find("Canvas Rooms").GetComponent<Canvas>();
            RoomNumberTextUI = canvas.transform.Find("Room number").GetComponent<TextMeshProUGUI>();
            //RoomUpdater = RoomNumber; // Esto nos permite cambiar el número de la room
        }
    }

    public void CalculateRoomIndex(int option)
    {
        if (option == 0) // AVANZAR DE ROOM
        {
            if (isInActualRoom)
            {
                if (RoomNumber == roomSL - 1)
                {
                    gameController.LoadNextRoom(indexSL);
                }
                else if (RoomNumber == roomLady - 1)
                {
                    gameController.LoadNextRoom(indexLady);
                }
                else
                {
                    // 1. Calcula un índice aleatorio
                    do
                    {
                        indiceRoomSiguiente = UnityEngine.Random.Range(numA, numB);
                    }
                    while (indiceRoomSiguiente == indiceRoomActual || indiceRoomSiguiente == indiceRoomAnterior);

                    // 2. Actualiza las variables que guardan los índices 
                    indiceRoomAnterior = SceneManager.GetActiveScene().buildIndex;
                    indiceRoomActual = indiceRoomSiguiente;

                    Debug.Log($"Room anterior: {indiceRoomAnterior} \nSiguiente room: {indiceRoomSiguiente}");

                    // 3. Carga la siguiente room
                    gameController.LoadNextRoom(indiceRoomSiguiente);
                }
            }
            else // Si está en la room en la cual ha retrocedido    
            {
                isInActualRoom = true;
                gameController.LoadNextRoom(indiceRoomActual);
            }
        }
        else if (option == 1) // RETROCEDER
        {
            isInActualRoom = false;

            Debug.Log($"Room actual: {indiceRoomActual}\nRoom anterior donde entramos: {indiceRoomAnterior}");

            gameController.LoadNextRoom(indiceRoomAnterior);
        }
    }

    void Update()
    {
        // Actualiza la UI que muestra el número de la room
        //RoomNumber = RoomUpdater;

        if (RoomNumberTextUI != null)
        {
            RoomNumberTextUI.text = "Room " + RoomNumber.ToString();
        }
    }
}