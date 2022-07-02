using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MagnetismEnd : MonoBehaviour
{
    BoxCollider2D[] colliders;
    PlayableDirector timeline;
    Animator[] animators;
    int counter = 0;

    void Start()
    {
        colliders = GetComponents<BoxCollider2D>();
        timeline = GetComponentInChildren<PlayableDirector>();
        animators = GetComponentsInChildren<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (counter < 1 && (colliders[0].IsTouchingLayers(LayerMask.GetMask("Magnetic")) && colliders[1].IsTouchingLayers(LayerMask.GetMask("Magnetic"))))
        {
            counter++;
            timeline.Play();
            animators[1].SetBool("switchToMidCam", true);
            StartCoroutine(Wait());

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6);
        animators[1].SetBool("switchToOutTowerCam", true);
    }
}
