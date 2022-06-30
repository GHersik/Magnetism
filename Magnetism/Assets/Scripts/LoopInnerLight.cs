using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LoopInnerLight : MonoBehaviour
{
    private Light2D light;
    [SerializeField] float delay = 3;
    [SerializeField] float lightIntensity = 1;
    [SerializeField] float lightIntensityOff = 0;
    int count = 1;

    void Start()
    {
        light = GetComponent<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (count <= 1)
        {
            count++;
            StartCoroutine(LightChange());
        }

    }

    IEnumerator LightChange()
    {
        float timeElapsed = 0;
        while (timeElapsed < delay)
        {
            light.intensity = Mathf.Lerp(lightIntensityOff, lightIntensity, timeElapsed / delay);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        light.intensity = 3;
    }
}
