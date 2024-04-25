using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoorStates : MonoBehaviour
{
    // Este script sirve para calcular si se puede o no retroceder de room.
    // Servirá en los casos como Lady o Skinny Legend, que son un solo nivel o "mini bosses",
    // no se deberían poder repetir este tipo de niveles.

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D boxCollider2D;
    public bool canGoBack = true;
    public RoomCounter roomCounter;

    void Start()
    {
        roomCounter = GameObject.Find("GameController").GetComponent<RoomCounter>();
        //if (roomCounter.RoomUpdater == roomCounter.roomSL+1)
        if (RoomCounter.RoomNumber == roomCounter.roomSL + 1 ||
            RoomCounter.RoomNumber == roomCounter.roomLady + 1 ||
            RoomCounter.RoomNumber == roomCounter.roomSL ||
            RoomCounter.RoomNumber == roomCounter.roomLady)
        {
            PlayerController.CanGoBack = false;
        }
    }

    void Update()
    {
        
    }
}