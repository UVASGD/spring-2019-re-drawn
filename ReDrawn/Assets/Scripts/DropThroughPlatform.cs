using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropThroughPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetAxis("Vertical") < 0)
        {
            collision.otherCollider.enabled = false;
            Invoke("ReEnableCollider", 0.5f);
        }
    }

    void ReEnableCollider()
    {
        Collider2D[] colliderList = gameObject.GetComponents<Collider2D>();
        foreach(Collider2D oneOfThem in colliderList)
        {
            oneOfThem.enabled = true;
        }
    }
}
