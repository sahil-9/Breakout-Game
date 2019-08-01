using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int Lives = 3;
	public int Bricks = 28;
	public float resetDelay;
	public Text TextLives = null;
	public GameObject gameOver = null;
	public GameObject youWon = null;
	public GameObject BricksPrefab = null;
	public GameObject Paddle = null;
	//--TODO need a reference to death paddle

	public GameObject DeathParticle = null;
	public static GameManager Instance = null;
	private GameObject clonePaddle = null;
		

	// Use this for initialization
	void Start () {
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy (gameObject);
		
		SetUp();
	}

	public void SetUp() {
		if(Paddle != null)
			clonePaddle = Instantiate (Paddle, Paddle.transform.position, Quaternion.identity) as GameObject;
		if (BricksPrefab != null)
			Instantiate (BricksPrefab, BricksPrefab.transform.position, Quaternion.identity);
	}

	void CheckGameOver() {
		if (Bricks < 1) {
			if (youWon != null) {
				youWon.SetActive(true);
				Time.timeScale = 0.025f;
				Invoke ("Reset", resetDelay);
			}
		}
		if (Lives < 1) {
			if (gameOver != null) {
				gameOver.SetActive(true);
				Time.timeScale = 0.25f;
				Invoke ("Reset", resetDelay);
			}
		}
	}

	void Reset() {
		Time.timeScale = 7f;
		SceneManager.LoadScene("Scene0");
	}	

	public void LoseLife() {
		Lives--;

		if (TextLives != null)
			TextLives.text = "Lives: " + Lives;
		//TODO instantiate death particles
		if (DeathParticle != null)
			Instantiate (DeathParticle, clonePaddle.transform.position, Quaternion.identity);

		//Debug.Log ("In loselife post deathparticle check");

		Destroy(clonePaddle.gameObject);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	private void SetupPaddle() {
		clonePaddle = Instantiate (Paddle, Paddle.transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick() {
		Bricks--;
		CheckGameOver ();
	}
}
