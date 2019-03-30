using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    bool jumping = false;
    public List<Transform> groundCheck;
    private int layermask;
    private float jumpForce = 10f;
    private float runForce = 10f;
    private float maxVelocity = 25f;
    private float skiddingThreshhold = 0.75f;
    private bool facingRight;

    void Start()
    {
        facingRight = transform.localScale.x > 0;
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();
        layermask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
        //print(layermask);
    }

    // Update is called once per frame
    void Update()
    {
        //print(myRigidBody.velocity);
        jumping = !(Physics2D.Linecast(transform.position, groundCheck[0].position, layermask) ||
                  Physics2D.Linecast(transform.position, groundCheck[1].position, layermask) ||
                  Physics2D.Linecast(transform.position, groundCheck[2].position, layermask));
        myAnimator.SetBool("Jumping", jumping);
        myAnimator.SetBool("Skidding", myRigidBody.velocity.magnitude > skiddingThreshhold && !jumping);
        if (Input.GetButtonDown("Jump") && !jumping)
        {
            //RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, new Vector2(0, -1));               
            myRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        //if (!Input.GetKey(KeyCode.Space)) {
        //    this.GetComponent<Animator>().SetBool("Jumping", false);
        //}
        if (Input.GetAxis("Horizontal") < 0)
        {
            myAnimator.SetBool("Running", true);
            if (facingRight)
            {
                Flip();
            }
            if (Mathf.Abs(myRigidBody.velocity.x) < maxVelocity)
            {
                myRigidBody.AddForce(new Vector2(-runForce, 0)); 
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            myAnimator.SetBool("Running", true);
            if (!facingRight)
            {
                Flip();
            }
            if (Mathf.Abs(myRigidBody.velocity.x) < maxVelocity)
            {
                myRigidBody.AddForce(new Vector2(runForce, 0)); 
            }
        }
        else {
            myAnimator.SetBool("Running", false);
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
