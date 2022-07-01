using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MagnetismEnd : MonoBehaviour
{
    BoxCollider2D[] colliders;
    PlayableDirector timeline;
    int counter = 0;

    void Start()
    {
        colliders = GetComponents<BoxCollider2D>();
        timeline = GetComponentInChildren<PlayableDirector>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (counter < 1 && (colliders[0].IsTouchingLayers(LayerMask.GetMask("Magnetic")) && colliders[1].IsTouchingLayers(LayerMask.GetMask("Magnetic"))))
        {
            timeline.Play();
            counter++;
        }
    }
}
