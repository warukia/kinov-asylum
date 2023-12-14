using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    // Esto es el código del armario para esconderse.

    [SerializeField] private Collider2D coll;
    [SerializeField] private ContactFilter2D contactFilter;
    private List<Collider2D> collidedObjects = new List<Collider2D>(1);

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        //coll.OverlapCollider(contactFilter, collidedObjects);
        //foreach(var o in collidedObjects)
        //{
        //    ClosetInteraction(o.gameObject);
        //}
    }

    protected virtual void ClosetInteraction(GameObject collidedObject)
    {
        //Debug.Log("Collided with " + collidedObject.name);

    }
}
