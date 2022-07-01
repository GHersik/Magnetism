using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Sequence : MonoBehaviour
{

    Light2D[] lights;
    [SerializeField] float delay = 3;
    [SerializeField] float lightIntensity = 1;
    [SerializeField] float lightIntensityOff = 0;

    void Start()
    {
        lights = GetComponentsInChildren<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Magnetic"))
        {
            foreach (var light in lights)
            {
                light.intensity = lightIntensity;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Magnetic"))
        {
            foreach (var light in lights)
            {
                StartCoroutine(LightChange(light));
            }
        }
    }

    IEnumerator LightChange(Light2D light)
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
