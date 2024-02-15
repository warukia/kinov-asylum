using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float FollowSpeed = 2f;
    private Transform target;
    private Transform doorPos;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        doorPos = GameObject.Find("Door").GetComponent<Transform>();
    }

    void Update()
    {
        // Nota: En el parkour de Skinny Legend si hacemos que salte cosas muy altas cambiarle el número 0 de la y al del personaje.
        Vector3 newPos = new Vector3(Mathf.Clamp(target.position.x, 0, (doorPos.position.x - 5.5f)), 0, -10);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}