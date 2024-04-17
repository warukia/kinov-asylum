using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingBricks : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    public CeilingBricksActivate ceilingBricksActivate;

    private float floorPos = -3.05f;


    void Start()
    {
        ceilingBricksActivate = gameObject.transform.GetChild(0).GetComponent<CeilingBricksActivate>();
    }

    void Update()
    {
        if (ceilingBricksActivate.IsActive)
        {
            rb.gravityScale = 1;
        }

        if (transform.position.y <= floorPos)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Destroy(col);
        }
    }
}
