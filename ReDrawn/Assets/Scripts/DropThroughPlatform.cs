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
            gameObject.GetComponent<Collider2D>().enabled = false;
            Invoke("ReEnableCollider", 0.5f);
        }
    }

    void ReEnableCollider()
    {
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
