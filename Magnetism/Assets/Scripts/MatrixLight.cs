using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class MatrixLight : MonoBehaviour
{
    private Light2D light;
    [SerializeField] float delay = 3;
    [SerializeField] float lightIntensity = 2;
    [SerializeField] float lightIntensityOff = 0;

    void Start()
    {
        light = GetComponent<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Magnetic"))
        {
            light.intensity = lightIntensity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Magnetic"))
        {
            StartCoroutine(LightChange());
        }
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
