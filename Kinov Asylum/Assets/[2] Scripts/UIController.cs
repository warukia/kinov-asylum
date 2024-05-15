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
    private GameController gameController;

    public AudioClip buttonClickClip;
    public AudioClip buttonOnTopClip;

    private void Start()
    {
        playerController = GameObject.Find("Player")?.GetComponent<PlayerController>();
        drawerController = GameObject.Find("Drawer")?.GetComponent<DrawerController>();
        gameController = GameObject.Find("GameController")?.GetComponent <GameController>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        // Reseteamos datos
        audioSource.PlayOneShot(buttonClickClip);
        RoomCounter.isInActualRoom = true;
        RoomCounter.indiceRoomActual = RoomCounter.indiceRoomAnterior = RoomCounter.RoomNumber = 0;
        DrawerController.levelsDrawerStates.Clear();
        gameController.LoadNextRoom(4);
    }

    //IEnumerator StartGameDelay()
    //{
    //    yield return new WaitForSeconds(.4f);
    //    SceneManager.LoadScene("Room0");
    //}

    public void MainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
        audioSource.PlayOneShot(buttonClickClip);
    }

    public void ExitGame()
    {
        Application.Quit();
        audioSource.PlayOneShot(buttonClickClip);
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