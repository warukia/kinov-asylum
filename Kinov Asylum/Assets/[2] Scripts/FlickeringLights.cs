using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlickeringLights : MonoBehaviour
{
    private Light2D lampLight;
    private float minWaitTime = 0.1f;
    private float maxWaitTime = 0.5f;

    void Start()
    {
        lampLight = GetComponent<Light2D>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            lampLight.intensity = Random.Range(.3f, .5f);
        }
    }
}