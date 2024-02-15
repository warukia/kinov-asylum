using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        transition = GameObject.Find("Canvas Rooms")?.transform.Find("Crossfade").GetComponent<Animator>();
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
        Debug.Log("Scene Loaded");
    }
}