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
    public Animator simonAnim;

    public AudioClip buttonClickClip;
    public AudioClip pillSwallowClip;

    private void Start()
    {
        playerController = GameObject.Find("Player")?.GetComponent<PlayerController>();
        drawerController = GameObject.Find("Drawer")?.GetComponent<DrawerController>();
        gameController = GameObject.Find("GameController")?.GetComponent<GameController>();
        simonAnim = GameObject.Find("OpenDrawer/Simon")?.GetComponent<Animator>();

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
        gameController.LoadNextRoom(8);
    }

    public void Credits()
    {
        audioSource.PlayOneShot(buttonClickClip, 1f);
        creditsPanel.SetActive(true);
    }

    public void MainMenu()
    {
        audioSource.PlayOneShot(buttonClickClip);
        gameController.LoadNextRoom(0);
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
        simonAnim.SetBool("simonAttack", true);
        StartCoroutine(waitForAnimationEndSimon());
    }

    private IEnumerator waitForAnimationEndSimon()
    {
        yield return new WaitForSeconds(.9f);
        drawerController.DisableSimon();
    }
}