using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum DrawerStates { Empty, Pill, Simon, SimonAndPill };

public class DrawerController : MonoBehaviour
{
    public static Dictionary<int, DrawerStates> levelsDrawerStates = new Dictionary<int, DrawerStates>();
    // El int del dictionary indica el número de la room. Significa que esto está diseñado para que haya
    // solo un cajón por room :p

    [SerializeField] private Transform trans;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Canvas canvas;

    public UnityEngine.UI.Image drawer;
    public UnityEngine.UI.Image pill;
    public UnityEngine.UI.Image simon;
    private GameObject drawerObject;

    public Transform PlayerPos;

    public bool IsActive;

    private bool CanOpenDrawer = false;
    private bool isOpened = false;


    void Start()
    {
        canvas = GameObject.Find("Canvas Rooms").GetComponent<Canvas>();
        drawerObject = canvas.transform.Find("OpenDrawer").GetComponent<GameObject>();
        RoomCounter roomCounter = GameObject.Find("GameController").GetComponent<RoomCounter>();

        drawer = canvas.transform.Find("OpenDrawer").GetComponent<UnityEngine.UI.Image>();
        pill = canvas.transform.Find("OpenDrawer/Pill").GetComponent<UnityEngine.UI.Image>();
        simon = canvas.transform.Find("OpenDrawer/Simon").GetComponent<UnityEngine.UI.Image>();

        drawer.enabled = false;
        pill.enabled = false;
        simon.enabled = false;

        // Cómo meter cosas en un diccionario
        //levelsDrawerStates.Add("Key", DrawerStates.Pill);

        // Para obtener el dato a partir de la key
        //levelsDrawerStates["Key"];

        // Saber si la key existe
        //levelsDrawerStates.ContainsKey("Key")




        // Entramos en el nivel

        // Miramos si no habíamos abierto ya antes el cajón
        string sceneName = SceneManager.GetActiveScene().name;
        
        // Si ya había algo en cajón
        if (levelsDrawerStates.ContainsKey(RoomCounter.RoomNumber))
        {
            switch (levelsDrawerStates[RoomCounter.RoomNumber])
            {
                case DrawerStates.Pill:

                    break;

                case DrawerStates.Simon:

                    break;

                case DrawerStates.SimonAndPill:

                    break;
            }
        }
        else // Si no había nada en el cajón (nueva room)
        {
            // Generamos aleatoriamente qué saldrá en el cajón
            Array values = Enum.GetValues(typeof(DrawerStates));
            System.Random random = new System.Random();
            DrawerStates randomBar = (DrawerStates)values.GetValue(random.Next(values.Length));

            levelsDrawerStates.Add(RoomCounter.RoomNumber, randomBar);


            //Debug.Log(levelsDrawerStates);

            //foreach (KeyValuePair<int, DrawerStates> s in levelsDrawerStates)
            //{
            //    Debug.Log(s.Key + ": " + s.Value);
            //}
        }

        Debug.Log(levelsDrawerStates[RoomCounter.RoomNumber]);
        
    }
    
    void Update()
    {
        if (CanOpenDrawer)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isOpened)
            {
                isOpened = true;
                DrawerState(true);
            }
            else if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && isOpened)
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

    // Detecta si se puede o no se puede abrir el cajón dependiendo
    // de si está en contacto con el jugador.
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

    // Abre el cajón
    public void DrawerState(bool open)
    {
        if (open)
        {
            DrawerStates currentState = levelsDrawerStates[RoomCounter.RoomNumber];
            drawer.gameObject.SetActive(true);
            drawer.enabled = true;

            switch (currentState)
            {            


                case DrawerStates.Simon:

                    simon.enabled = true;

                    break;

                case DrawerStates.SimonAndPill:
                    pill.enabled = true;
                    simon.enabled = true;

                    break;

                case DrawerStates.Pill:

                    pill.enabled = true;
                    break;

                




            }



        }


        //if (levelsDrawerStates.ContainsValue(DrawerStates.SimonAndPill) && open)
        //{
        //    drawer.enabled = true;
        //    pill.enabled = true;
        //    simon.enabled = true;
        //}
        //else if (levelsDrawerStates.ContainsValue(DrawerStates.Simon) && open)
        //{
        //    drawer.enabled = true;
        //    pill.enabled = false;
        //    simon.enabled = true;
        //}
        //else if (levelsDrawerStates.ContainsValue(DrawerStates.Pill) && open)
        //{
        //    drawer.enabled = true;
        //    pill.enabled = true;
        //    simon.enabled = false;
        //}
        //else if (levelsDrawerStates.ContainsValue(DrawerStates.Empty) && open)
        //{
        //    drawer.enabled = true;
        //    pill.enabled = false;
        //    simon.enabled = false;
        //}
        //else
        //{
        //    drawer.enabled = false;
        //    pill.enabled = false;
        //    simon.enabled = false;
        //}
    }
}