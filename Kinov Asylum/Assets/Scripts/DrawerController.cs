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
            // se mostrar� el sprite del caj�n en la derecha arriba.
        }
        else
        {
            // se mostrar� el sprite del caj�n en la izquierda.
        }
    }
}
