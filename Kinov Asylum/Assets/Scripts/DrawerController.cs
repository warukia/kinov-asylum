using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DrawerController : MonoBehaviour
{
    public static Dictionary<string, DrawerStates> levelsDrawerStates = new Dictionary<string, DrawerStates>();

    public enum DrawerStates { Empty, Pill, Simon, SimonAndPill };

    [SerializeField] private Transform trans;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Canvas canvas;

    private UnityEngine.UI.Image drawer;
    private UnityEngine.UI.Image pill;
    private UnityEngine.UI.Image simon;
    private GameObject drawerObject;


    public Transform PlayerPos;

    public bool IsActive;

    private bool CanOpenDrawer = false;
    private bool isOpened = false;


    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        drawerObject = canvas.transform.Find("OpenDrawer").GetComponent<GameObject>();
        drawer = canvas.transform.Find("OpenDrawer").GetComponent<UnityEngine.UI.Image>();


        drawer.enabled = false;

        // C�mo meter cosas en un diccionario
        //levelsDrawerStates.Add("Key", DrawerStates.Pill);

        // Para obtener el dato a partir de la key
        //levelsDrawerStates["Key"];

        // Saber si la key existe
        //levelsDrawerStates.ContainsKey("Key")




        // Entramos en el nivel

        // Miramos si no hab�amos abierto ya antes el caj�n
        string sceneName = SceneManager.GetActiveScene().name;

        // Si ya hab�a algo en caj�n
        if (levelsDrawerStates.ContainsKey(sceneName))
        { 
                    
        }
        else
        {
            // Generamos aleatoriamente
            Array values = Enum.GetValues(typeof(DrawerStates));
            System.Random random = new System.Random();
            DrawerStates randomBar = (DrawerStates)values.GetValue(random.Next(values.Length));

            levelsDrawerStates.Add(sceneName, randomBar);  


        }
    }

    void Update()
    {
        if (CanOpenDrawer)
        {
            if (Input.GetKeyDown(KeyCode.E) && isOpened == false)
            {
                isOpened = true;
                DrawerState(true);
            }
            else if (Input.GetKeyDown(KeyCode.E) && isOpened == true)
            {
                isOpened = false;
                DrawerState(false);
            }
        }
        else
        {
            DrawerState(false);
        }
    }

    // Detecta si se puede o no se puede abrir el caj�n dependiendo
    // de si est� en contacto con el jugador.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CanOpenDrawer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) CanOpenDrawer = false;
    }

    // Abre el caj�n
    public void DrawerState(bool open)
    {
        drawer.enabled = open;
    }
}