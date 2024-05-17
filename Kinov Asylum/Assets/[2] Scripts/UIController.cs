using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private DrawerController drawerController;
    private PlayerController playerController;
    private GameController gameController;
    public GameObject creditsPanel;

    public AudioClip buttonClickClip;
    public AudioClip pillSwallowClip;

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
        audioSource.PlayOneShot(buttonClickClip, 1f);
        HarryDoor.isExploding = false;
        RoomCounter.isInActualRoom = true;
        RoomCounter.indiceRoomActual = RoomCounter.indiceRoomAnterior = RoomCounter.RoomNumber = 0;
        DrawerController.levelsDrawerStates.Clear();
        gameController.LoadNextRoom(6);
    }

    public void Credits()
    {
        audioSource.PlayOneShot(buttonClickClip, 1f);
        creditsPanel.SetActive(true);
    }


    //IEnumerator StartGameDelay()
    //{
    //    yield return new WaitForSeconds(.4f);
    //    SceneManager.LoadScene("Room0");
    //}

    public void MainMenu()
    {
        audioSource.PlayOneShot(buttonClickClip);
        SceneManager.LoadScene("01_MainMenu");
    }

    public void ExitGame()
    {
        audioSource.PlayOneShot(buttonClickClip);
        Application.Quit();
    }


    public void Pill()
    {
        if (PlayerController.health < 100)
        {
            audioSource.PlayOneShot(pillSwallowClip);
            playerController.TakeDamage(-10);
            drawerController.DisablePill();
        }
    }

    public void Simon()
    {
        playerController.TakeDamage(30);
        drawerController.DisableSimon();
    }


}