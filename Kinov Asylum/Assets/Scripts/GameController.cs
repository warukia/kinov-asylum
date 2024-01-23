using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private int numA = 2;
    private int numB = 7;

    void Update()
    {
        
    }

    // CARGAR SIGUIENTE ROOM ALEATORIAMENTE
    public void LoadNextRoom()
    {
        StartCoroutine(LoadNextRoomCoroutine());
    }

    IEnumerator LoadNextRoomCoroutine()
    {
        // Iniciar animación
        transition.SetTrigger("Start");

        // Espera un poco
        yield return new WaitForSeconds(transitionTime);

        // Calcular el nivel que cargará
        int index = Random.Range(numA, numB);
        int lastNumber = 0;
        if (index == lastNumber)
        {
            index = Random.Range(numA, numB);
        }
        lastNumber = index;

        // Carga el nivel
        SceneManager.LoadScene(index);
        Debug.Log("Scene Loaded");
    }
}