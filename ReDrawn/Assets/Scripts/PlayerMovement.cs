using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, new Vector2(0, -1));
            //if (Mathf.Approximately(hit.distance, 0.0f))
            {
                rb.AddForce(new Vector2(0, 100));
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Animator>().SetBool("Running", true);
            this.transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(new Vector2(-10, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<Animator>().SetBool("Running", true);
            this.transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(new Vector2(10, 0));
        }
        else {
            this.GetComponent<Animator>().SetBool("Running", false);
        }
    }
}
