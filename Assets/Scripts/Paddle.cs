using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;
	private Vector3 playerPos = new Vector3(0f, -9f, 0f);


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed);
		playerPos = new Vector3(Mathf.Clamp(xPos, -7.5f, 7.5f), -9f, 0f);
		transform.position = playerPos;
	}
}
