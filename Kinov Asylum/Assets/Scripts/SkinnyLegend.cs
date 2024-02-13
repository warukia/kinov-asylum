using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinnyLegend : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private Rigidbody2D rb;
    public SkinnyLegendActivation skinnyLegendActivation;

    public int secondsActivation = 5;
    public float speed = 5.5f;
    public bool IsActive = false;

    void Update()
    {
        // Se activa si el collider de activación se vuelve true
        IsActive = skinnyLegendActivation.IsActive;

        if (IsActive)
        {
            StartCoroutine(Activation());
        }
    }

    private IEnumerator Activation() // Saldrá de la pared.
    {
        // Aqui tengo que poner un booleano que active la animacion de entrada de skinny legend

        yield return new WaitForSeconds(secondsActivation);
        rb.velocity = new Vector2(speed, 0);
    }
}