using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    bool jumping = false;
    public Transform groundCheck;
    private int layermask;
    void Start()
    {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();
        layermask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
        print(layermask);
    }

    // Update is called once per frame
    void Update()
    {
        jumping = !Physics2D.Linecast(transform.position, groundCheck.position, layermask);
        myAnimator.SetBool("Jumping", jumping);
        if (Input.GetKey(KeyCode.Space) && !jumping)
        {
            //RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, new Vector2(0, -1));               
            myRigidBody.AddForce(new Vector2(0, 150));
        }
        //if (!Input.GetKey(KeyCode.Space)) {
        //    this.GetComponent<Animator>().SetBool("Jumping", false);
        //}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myAnimator.SetBool("Running", true);
            this.transform.localScale = new Vector3(-1, 1, 1);
            myRigidBody.AddForce(new Vector2(-10, 0));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myAnimator.SetBool("Running", true);
            this.transform.localScale = new Vector3(1, 1, 1);
            myRigidBody.AddForce(new Vector2(10, 0));
        }
        else {
            this.GetComponent<Animator>().SetBool("Running", false);
        }
    }



    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // this is hacky, we are just trying to test jump animations
    //    if (collision.collider.tag == "Platform") {
    //        jumping = false;
    //        this.GetComponent<Animator>().SetBool("Jumping", false);
    //    }
    //}
}
