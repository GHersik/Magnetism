using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    Rigidbody2D rigidBody;
    CircleCollider2D circleCollider;
    List<Rigidbody2D> listOfAttractables;

    Vector2 posToAttractTo;
    bool isAttracted = false;
    [SerializeField] float attractionRate = 0;
    [SerializeField] float attractionRadius = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponentInChildren<CircleCollider2D>();
        listOfAttractables = new List<Rigidbody2D>();
    }

    void Update()
    {
        if (isAttracted)
        {
            //posToAttractTo = -(transform.position)
            rigidBody.velocity = posToAttractTo;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Magnetic"))
        {
            //Physics2D.OverlapArea();
            Debug.Log("Attract!");
            Debug.Log($"{circleCollider.radius}");
            listOfAttractables.Add(collision.attachedRigidbody);
            isAttracted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Magnetic"))
        {
            Debug.Log("Left attraction zone!");

            listOfAttractables.Remove(collision.attachedRigidbody);


            isAttracted = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(rigidBody.position, attractionRadius);
    }
}
