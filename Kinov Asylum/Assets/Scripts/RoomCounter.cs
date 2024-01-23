using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomCounter : MonoBehaviour
{
    public float RoomUpdater;
    private static float RoomNumber; 
    public TextMeshProUGUI RoomNumberTextUI;

    void Start()
    {
        RoomUpdater = RoomNumber;
    }

    void Update()
    {
        RoomNumber = RoomUpdater;
        RoomNumberTextUI.text = "Room " + RoomNumber.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}