using UnityEngine;
using System.Collections;

public class MoveAsteroid : MonoBehaviour {
	private Transform asteroid;
	private float rX, rY, rZ;
	private float dX, dY, dZ;
    
	public float multiplier;

	// Use this for initialization
	void Start() {
		asteroid = this.gameObject.transform;

		//Set rotation
		rX = Random.Range(-45, 45);
		rY = Random.Range(-45, 45);
		rZ = Random.Range(-45, 45);

		//Set translation direction
		dX = Random.Range(-2f, 2f);
		dY = Random.Range(-2f, 2f);
		dZ = Random.Range(-10f, -9f);
        
		this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(dX, dY, dZ) * multiplier * GameManager.Instance.RelativeDifficultyRate);
		this.gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(rX, rY, rZ));
	}
	
	// Update is called once per frame
	void Update() {
		//asteroid.Translate(new Vector3(dX, dY, dZ) * Time.deltaTime, Space.World);
		//asteroid.Rotate(new Vector3(rX, rY, rZ) * Time.deltaTime);
		if((asteroid.position.x > SpawnAsteroids.ASTEROID_MAX_X || asteroid.position.x < SpawnAsteroids.ASTEROID_MIN_X) &&
		   (asteroid.position.y > SpawnAsteroids.ASTEROID_MAX_Y || asteroid.position.y < SpawnAsteroids.ASTEROID_MIN_Y) ||
		   (asteroid.position.z > SpawnAsteroids.ASTEROID_MAX_Z || asteroid.position.z < SpawnAsteroids.ASTEROID_MIN_Z)) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "Asteroid" + @".*") {
			BounceAsteroid(asteroid, col.gameObject.transform);
		}
	}

	void BounceAsteroid(Transform asteroid1, Transform asteroid2) {

	}
}
