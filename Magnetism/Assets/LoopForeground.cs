using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopForeground : MonoBehaviour
{
    EdgeCollider2D edgeCollider;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        edgeCollider.enabled = false;
        spriteRenderer.sortingOrder = 5;
    }
}
