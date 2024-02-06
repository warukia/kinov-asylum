using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DrawerController : MonoBehaviour
{
    public enum DrawerStates { Empty, Pill, Simon };

    [SerializeField] private Transform trans;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private SpriteRenderer openDrawerRenderer;

    public Transform PlayerPos;

    public bool IsActive;

    private bool CanOpenDrawer = false;
    private bool isOpened = false;


    void Start()
    {
        openDrawerRenderer = gameObject.transform.Find("Drawer_UI").GetComponent<SpriteRenderer>();
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

    public void DrawerState(bool open)
    {
        openDrawerRenderer.enabled = open;
    }
}