using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    EdgeCollider2D edgeCollider;

    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        edgeCollider.enabled = true;
    }
}
