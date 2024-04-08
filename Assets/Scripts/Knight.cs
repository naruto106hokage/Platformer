using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TouchingDirections), typeof(Rigidbody2D))]
public class Knight : MonoBehaviour
{
    public float walkSpeed = 3f;
    Rigidbody2D rb;

    public enum WalkableDirection { Right, Left }
    private WalkableDirection _walkDirection;
    public Vector2 walkableDirectionVector = Vector2.right;
    TouchingDirections touchingDirections;
    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    walkableDirectionVector = Vector2.right;

                }
                else if (value == WalkableDirection.Left)
                {
                    walkableDirectionVector = Vector2.left;
                }
            }
            _walkDirection = value;
        }

    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void FixedUpdate()
    {
        if (touchingDirections.IsOnWall && touchingDirections.IsGrounded)
        {
            FlipDirection();
        }
        //Debug.Log();
        rb.velocity = new Vector2(walkSpeed * walkableDirectionVector.x, rb.velocity.y);

    }

    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection= WalkableDirection.Left;
        }
        else if(WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else
        {
            Debug.Log("Current walkable direction is not set to left or right ");
        }
    }
}
