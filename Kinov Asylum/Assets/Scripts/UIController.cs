using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private DrawerController drawerController;
    private void Start()
    {

    }

    public void StartGame()
    {
        // Reseteamos datos
        RoomCounter.isInActualRoom = true;
        RoomCounter.indiceRoomActual = RoomCounter.indiceRoomAnterior = RoomCounter.RoomNumber = 0;
        drawerController = GameObject.Find("Drawer")?.GetComponent<DrawerController>();
        DrawerController.levelsDrawerStates.Clear();
        SceneManager.LoadScene("Room0");
    }

    public void Pill()
    {
        if (PlayerController.health < 100)
        {
            PlayerController.health += 10;
            //drawerController.pill.enabled = false;
        }
        Debug.Log("Health + 10");
    }

    public void Simon()
    {
        PlayerController.health -= 10;
        Debug.Log("ola soi simon :B tematare");
    }
}