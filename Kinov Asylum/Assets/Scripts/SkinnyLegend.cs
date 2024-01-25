using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinnyLegend : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private Rigidbody2D rb;
    public SkinnyLegendActivation skinnyLegendActivation;

    public float speed = 5f;
    public bool IsActive = false;

    void Update()
    {
        IsActive = skinnyLegendActivation.IsActive;

        if (IsActive)
        {
            StartCoroutine(Activation());
        }
    }

    private IEnumerator Activation()
    {
        int seconds = 5;
        // Aqui tengo que poner un booleano que active la animacion de entrada de skinny legend

        yield return new WaitForSeconds(seconds);
        rb.velocity = new Vector2(speed, 0);

    }
}