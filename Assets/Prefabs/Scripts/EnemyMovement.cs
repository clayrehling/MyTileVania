using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Rigidbody2D myRigidbody2D;
    [SerializeField] float moveSpeed = 1f;


	void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();

	}
	
	void Update () {
        myRigidbody2D.velocity = new Vector2(moveSpeed, 0);

	}
}
