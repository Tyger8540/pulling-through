using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public LayerMask jumpableGround;

    public float dirX = 0f;

    public float defaultMoveSpeed = 5f;
    public float moveSpeed;
    public float jumpForce;
    public float sprintSpeed;
    public float lowerBound;
    public Vector3 startingPosition;

    public bool inShadowMode = false;

    public PlayerPathing pathingScript;
    public int currentWaypointIndex = 0;
    public bool shadowIsMoving = false;

    //private bool movingRight;
    //private bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        moveSpeed = defaultMoveSpeed;
        startingPosition = transform.position;
        pathingScript = FindObjectOfType<PlayerPathing>();
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
        if (inShadowMode && CompareTag("Shadow"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !shadowIsMoving)
            {
                shadowIsMoving = true;
            }
            else if (shadowIsMoving)
            {
                if (Vector2.Distance(pathingScript.path[currentWaypointIndex], transform.position) < .1f)
                {
                    currentWaypointIndex++;
                    shadowIsMoving = false;
                }
                transform.position = Vector2.MoveTowards(transform.position, pathingScript.path[currentWaypointIndex], Time.deltaTime * sprintSpeed);
            }
        }
        else
        {
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

            if (transform.position.y <= lowerBound)
            {
                Respawn(startingPosition);
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Respawn(Vector3 spawnpoint)
    {
        transform.position = spawnpoint;
        // probably will do more like decrease lives and stuff
    }
}
