using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool resetPencils = true;
    private bool alreadyHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!alreadyHit && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().currentCheckpoint = this;
            if (resetPencils)
            {
                collision.gameObject.GetComponent<Drawing2>().ResetPencils();
            }
            alreadyHit = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
