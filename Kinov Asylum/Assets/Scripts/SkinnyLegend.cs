using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinnyLegend : MonoBehaviour
{
    [SerializeField] private Transform trans;

    public float speed = 5f;
    public bool IsActive = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (IsActive)
        {
            trans.Translate(new Vector3(speed, 0, 0));
        }
    }
}
