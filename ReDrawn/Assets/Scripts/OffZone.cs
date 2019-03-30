using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffZone : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.position = initialPosition;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
