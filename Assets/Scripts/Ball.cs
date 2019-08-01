using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 600f;
	private Rigidbody ballRigidbody = null;
	private bool isBallInPlay = false;

	void Awake() {
		ballRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && !isBallInPlay) {
			transform.parent = null;
			isBallInPlay = true;
			ballRigidbody.isKinematic = false;
			ballRigidbody.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0f));

		}	
	}
}
