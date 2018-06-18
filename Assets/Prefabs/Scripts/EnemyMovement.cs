using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Rigidbody2D myRigidbody2D;
    [SerializeField] float moveSpeed = 1f;
	// Use this for initialization
	void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 moveRight = new Vector3(moveSpeed, 0, 0);
        //transform.position = transform.position + moveRight;

        myRigidbody2D.velocity = new Vector2(moveSpeed, 0);
	}
}
