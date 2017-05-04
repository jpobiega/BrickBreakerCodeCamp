using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bricks : MonoBehaviour {

	public GameObject brickParticle;
	public int hitsToKill;
	private int numberOfHits;
	public int brickpts;


	public Transform powerUpSizeObj;
	public int powerSelector;


	void Start()
	{
		numberOfHits = 0;
	}

	void OnCollisionEnter(Collision collision)
	{
		powerSelector = Random.Range (1, 10);
		
		if (collision.gameObject.tag == "Ball") {
			numberOfHits++;
		}

		if (numberOfHits == hitsToKill) {
			
			if (powerSelector == 1) {
			
				Instantiate (powerUpSizeObj, transform.position, powerUpSizeObj.rotation);
			}

			Instantiate (brickParticle, transform.position, Quaternion.identity);
			GM.instance.AddScore (brickpts);
			GM.instance.DestroyBrick();
			Destroy (gameObject);
		}

	}
}
