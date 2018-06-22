using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class EnemyMovement : MonoBehaviour {
    Rigidbody2D myRigidbody2D;
    [SerializeField] float moveSpeed = 1f;

    void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (IsFacingRight())
        {
            myRigidbody2D.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidbody2D.velocity = new Vector2(-moveSpeed, 0);
        }
	}

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody2D.velocity.x)), 1f);
    }
}
