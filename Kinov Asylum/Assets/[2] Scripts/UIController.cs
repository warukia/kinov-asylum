using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private AudioSource audioSource;
    private DrawerController drawerController;
    private PlayerController playerController;

    public AudioClip clickClip;

    private void Start()
    {
        playerController = GameObject.Find("Player")?.GetComponent<PlayerController>();
        drawerController = GameObject.Find("Drawer")?.GetComponent<DrawerController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        // Reseteamos datos
        audioSource.PlayOneShot(clickClip);
        RoomCounter.isInActualRoom = true;
        RoomCounter.indiceRoomActual = RoomCounter.indiceRoomAnterior = RoomCounter.RoomNumber = 0;
        DrawerController.levelsDrawerStates.Clear();
        SceneManager.LoadScene("Room0");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        audioSource.PlayOneShot(clickClip);
    }

    public void ExitGame()
    {
        Application.Quit();
        audioSource.PlayOneShot(clickClip);
    }

    public void Pill()
    {
        if (PlayerController.health < 100)
        {
            playerController.TakeDamage(-10);
            drawerController.DisablePill();
        }
    }

    public void Simon()
    {
        playerController.TakeDamage(10);
        drawerController.DisableSimon();
    }
}