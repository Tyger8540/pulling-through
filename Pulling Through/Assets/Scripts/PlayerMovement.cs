using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public LayerMask jumpableGround;

    private float dirX = 0f;

    public float defaultMoveSpeed = 5f;
    public float moveSpeed;
    public float jumpForce;
    public float sprintSpeed;

    //private bool movingRight;
    //private bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        moveSpeed = defaultMoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (rb.velocity.x > 0f)
        {
            movingRight = true;
            movingLeft = false;
        }
        else if (rb.velocity.x < 0f)
        {
            movingLeft = true;
            movingRight = false;
        }*/
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
        {
            moveSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = defaultMoveSpeed;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
