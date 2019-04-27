using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingObject : MonoBehaviour
{

    public float timeToCombine = 0.0f;

    void Start()
    {
        timeToCombine = Time.time + .5f;
    }

    void OnCollisionEnter2D(Collision2D collisioninfo)
    {
        if (Time.time < timeToCombine && collisioninfo.collider.tag == "Drawing")
        {
            FixedJoint2D currJoint = gameObject.AddComponent<FixedJoint2D>();
            currJoint.connectedBody = collisioninfo.collider.attachedRigidbody;
            currJoint.enableCollision = false;
        }
    }
}
