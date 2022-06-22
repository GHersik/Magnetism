using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubeStart : MonoBehaviour
{
    [SerializeField] Vector2 Force = new Vector2(0, 0);
    Rigidbody2D Cube;
    int Count = 0;
    [SerializeField] ParticleSystem ParticleTop;
    [SerializeField] ParticleSystem ParticleBottom;
    [SerializeField] float Delay = 0;

    void Start()
    {
        Cube = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonUp("Jump"))
        {
            //if (Count > 0)
            //    return;

            Count++;
            ParticleBottom.Play();
            ParticleTop.Play();
            StartCoroutine(StartWait());
        }
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(Delay);
        Cube.AddForce(Force);
    }
}
