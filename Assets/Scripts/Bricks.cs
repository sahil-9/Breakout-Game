using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {

	public GameObject BricksParticle = null;

	void OnCollisionEnter(Collision other) {
		if(BricksParticle != null)
			Instantiate (BricksParticle, transform.position, Quaternion.identity);

		GameManager.Instance.DestroyBrick ();
		Destroy (gameObject);
	}
}
