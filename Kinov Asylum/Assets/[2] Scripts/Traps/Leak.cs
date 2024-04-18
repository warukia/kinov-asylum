using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour
{
    public GameObject LeakDrop;
    private int spawnTime = 2;

    void Start()
    {
        InvokeRepeating("SpawnDrop", spawnTime, spawnTime);
    }

    void Update()
    {

    }

    public void SpawnDrop()
    {
        Instantiate(LeakDrop, new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z), Quaternion.identity);
    }
}