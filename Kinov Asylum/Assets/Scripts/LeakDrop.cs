using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakDrop : MonoBehaviour
{
    private Transform floorTransform;

    void Start()
    {
        floorTransform = GameObject.Find("LeakFloor").GetComponent<Transform>();


    }

    void Update()
    {
        if (gameObject.transform.position.y <= floorTransform.position.y)
        {
            Destroy(gameObject);
        }
    }
}