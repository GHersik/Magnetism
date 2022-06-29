using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Ramp2D : MonoBehaviour
{
    private Light2D light;
    [SerializeField] float delay = 3;
    [SerializeField] float lightIntensity = 1;
    [SerializeField] float lightIntensityOff = 0;

    void Start()
    {
        light = GetComponent<Light2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(LightChange());
    }

    IEnumerator LightChange()
    {
        float timeElapsed = 0;
        while (timeElapsed < delay)
        {
            light.intensity = Mathf.Lerp(lightIntensity, lightIntensityOff, timeElapsed / delay);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        light.intensity = lightIntensityOff;
    }
}
