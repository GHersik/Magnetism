using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorTimeLine : MonoBehaviour
{
    PlayableDirector timeline;

    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timeline.Play();
    }
}
