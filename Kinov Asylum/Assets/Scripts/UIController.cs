using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private void Start()
    {

    }

    public void StartGame()
    {
        // Reseteamos datos
        RoomCounter.isInActualRoom = true;
        RoomCounter.indiceRoomActual = RoomCounter.indiceRoomAnterior = RoomCounter.RoomNumber = 0;
        DrawerController.levelsDrawerStates.Clear();
        SceneManager.LoadScene("Room0");
    }

    public void Pill()
    {
        Debug.Log("soi la pastilla :D");
    }

    public void Simon()
    {
        Debug.Log("ola soi simon :B tematare");
    }
}