using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public Animator transition;
    private Canvas canvas;
    public float transitionTime = 1f;

    private void Start()
    {
        if (GameObject.Find("MainMenu") != null)
        {
            // Esto lo que hace es pillar la transición desde el MainMenu porque el Canvas de ahí se llama
            // de distinta manera y si no pongo eso no detecta ninguno.
            transition = GameObject.Find("MainMenu").transform.Find("Crossfade").GetComponent<Animator>();
        }
        else if (GameObject.Find("Canvas Rooms") != null)
        {
            transition = GameObject.Find("Canvas Rooms")?.transform.Find("Crossfade").GetComponent<Animator>();
        }
        else
        {
            transition = GameObject.Find("GameOver Canvas")?.transform.Find("Crossfade").GetComponent<Animator>();
        }
        

        if (GameObject.Find("Canvas Rooms") != null) canvas = GameObject.Find("Canvas Rooms").GetComponent<Canvas>();

        if (GameObject.Find("Drawer") == null && GameObject.Find("Canvas Rooms") != null)
        {
                canvas.transform.Find("OpenDrawer").GetComponent<UnityEngine.UI.Image>().enabled = false;
                canvas.transform.Find("OpenDrawer/Pill").GetComponent<UnityEngine.UI.Image>().enabled = false;
                canvas.transform.Find("OpenDrawer/Simon").GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
    }

    // Carga una room con una transición negra.
    public void LoadNextRoom(int roomIndex)
    {
        StartCoroutine(LoadNextRoomCoroutine(roomIndex));
    }

    IEnumerator LoadNextRoomCoroutine(int roomIndex)
    {
        // Iniciar animación
        transition.SetTrigger("Start");

        // Espera un poco
        yield return new WaitForSeconds(transitionTime);

        // Carga el nivel
        SceneManager.LoadScene(roomIndex);
        //Debug.Log("Scene Loaded");
    }
}