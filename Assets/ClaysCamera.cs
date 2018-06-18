using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaysCamera : MonoBehaviour {

    public GameObject player;
    public int cameraZDepth;
    Vector3 cameraZOffset;
    Vector3 playerPos;



	// Use this for initialization
	void Start () {
        cameraZOffset = new Vector3(0, 0, cameraZDepth);


        transform.position = player.transform.position + cameraZOffset;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + cameraZOffset;
	}
}
