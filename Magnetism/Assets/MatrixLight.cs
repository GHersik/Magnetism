using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class MatrixLight : MonoBehaviour
{
    Light2D light;

    void Start()
    {
        light = GetComponent<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Magnetic"))
        {
            light.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Magnetic"))
        {
            light.enabled = false;
        }
    }
}
