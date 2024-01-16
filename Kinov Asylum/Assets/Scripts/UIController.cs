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
        SceneManager.LoadScene("Room0");
    }
}
