using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    public enum DrawerStates { Empty, Pill, Simon };

    [SerializeField] private Transform trans;
    public Transform PlayerPos;

    public bool IsActive;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void OpenDrawer()
    {
        if (PlayerPos.position.x <= trans.position.x)
        {
            // se mostrará el sprite del cajón en la derecha arriba.
        }
        else
        {
            // se mostrará el sprite del cajón en la izquierda.
        }
    }
}
