using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;

	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);
	
	// Update is called once per frame
	void Update () {
	
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp (xPos, -8f, 8f), -9.5f, 0f);
		transform.position = playerPos;
	}

	void OnTriggerEnter(Collider power)
	{
		if (power.gameObject.name == "PowerUpSize(Clone)") {

			GameObject.FindGameObjectWithTag ("Paddle").transform.localScale = new Vector3 (5, 1, 1);
			Destroy (power.gameObject);

		}
	}
}
