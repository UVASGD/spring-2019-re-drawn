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
    public float jumpForce = 10f;
    public float runForce = 10f;
    public float maxVelocity = 25f;
    public float skiddingThreshhold = 0.75f;
    private bool facingRight;
    private Vector2 forceDirection;
    public bool paused = false;
    private Vector3 initialPosition;
    public Vector3 checkpointPosition;

    void Start()
    {
        initialPosition = transform.position;
        checkpointPosition = initialPosition;
        facingRight = transform.localScale.x > 0;
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myAnimator = gameObject.GetComponent<Animator>();
        layermask = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
        forceDirection = Vector2.right;
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
        myAnimator.SetBool("Running", Input.GetAxis("Horizontal") != 0);
        if (jumping)
        {
            forceDirection = Vector2.right;
        }
        if (Input.GetButtonDown("Jump") && !jumping && !paused)
        {
            //RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, new Vector2(0, -1));               
            myRigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        //if (!Input.GetKey(KeyCode.Space)) {
        //    this.GetComponent<Animator>().SetBool("Jumping", false);
        //}
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (facingRight)
            {
                Flip();
            }
            if (Mathf.Abs(myRigidBody.velocity.x) < maxVelocity)
            {
                myRigidBody.AddForce(-forceDirection * runForce); 
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (!facingRight)
            {
                Flip();
            }
            if (Mathf.Abs(myRigidBody.velocity.x) < maxVelocity)
            {
                myRigidBody.AddForce(forceDirection * runForce); 
            }
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 totalNormal = Vector2.zero;
        for(int i = 0; i < collision.contactCount; i++)
        {
            totalNormal += collision.contacts[i].normal;
        }
        forceDirection = -Vector2.Perpendicular(totalNormal).normalized;
    }

    private void Reset(Vector3 position)
    {
        transform.position = position;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Animator>().Play("PlaceholderIdle");
        GameObject[] drawings = GameObject.FindGameObjectsWithTag("Drawing");
        for (int z = 0; z < drawings.Length; z++)
        {
            Destroy(drawings[z]);
        }
        GetComponent<Drawing2>().ResetPencils();
    }

    public void ResetTotal()
    {
        Reset(initialPosition);
        checkpointPosition = initialPosition;
    }

    public void ResetCheckpoint()
    {
        Reset(checkpointPosition);
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
