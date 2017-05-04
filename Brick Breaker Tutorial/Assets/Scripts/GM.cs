using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public Text scoreText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	public int Score;

	public GameObject clonePaddle;

	// Use this for initialization
	void Start () {
		Score = 0;
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		Setup ();
		
	}

	public void Setup()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1) {
			youWon.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

		if (lives < 1) {
			gameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

	}

	void Reset()
	{
		Time.timeScale = 1f;
		//Application.LoadLevel (Application.loadedLevel)
		SceneManager.LoadScene("default");

	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		ClearPowerUps ();
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	void ClearPowerUps()
	{
		if (GameObject.FindGameObjectsWithTag("PowerUpSize") != null){
		GameObject[] PowerUps = GameObject.FindGameObjectsWithTag ("PowerUpSize");
		foreach (GameObject p in PowerUps)
			Destroy (p);
		}
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void AddScore(int newScoreValue){
		Score += newScoreValue;
		scoreText.text = "Score: " + Score;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver ();
	}


}
