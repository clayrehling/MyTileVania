using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;


    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    Collider2D myCollider2D;
    float gravityScaleAtStart;

    // Message then methods (?)
    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
        gravityScaleAtStart = myRigidbody2D.gravityScale;
    }
    private void Update()
    {
        Run();
        Jump();
        ClimbLadder();
        FlipSprite();
    }

    private void ClimbLadder()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladders")))
        {
            myRigidbody2D.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("Climbing", false);
            return;
        }
        print("collided with ladders layer");
        float climbThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 playerVelocity = new Vector2(myRigidbody2D.velocity.x, climbThrow * climbSpeed);
        myRigidbody2D.velocity = playerVelocity;
        myRigidbody2D.gravityScale = 0f;
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody2D.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
    }

    private void Run()
    {
        // Let's see if this is needed: (can you run off the ladder?
        // if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // from -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void Jump()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if ((CrossPlatformInputManager.GetButtonDown("Jump")))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody2D.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }





}
