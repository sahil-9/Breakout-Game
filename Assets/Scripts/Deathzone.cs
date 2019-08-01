using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		//Debug.Log ("In loselife post deathparticle check");
		GameManager.Instance.LoseLife ();
	}
}
