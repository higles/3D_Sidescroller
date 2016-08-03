using UnityEngine;
using System.Collections;

public class MoveAsteroid : MonoBehaviour {
    private Transform asteroid;
    private float rX, rY, rZ;

	// Use this for initialization
	void Start () {
        asteroid = this.gameObject.transform;

        rX = Random.Range(-45, 45);
        rY = Random.Range(-45, 45);
        rZ = Random.Range(-45, 45);
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 rot = asteroid.rotation.eulerAngles;
        //rot = rot + new Vector3(rX, rY, rZ) * Time.deltaTime;

        asteroid.Translate(new Vector3(0, 0, -3f) * Time.deltaTime, Space.World);
        asteroid.Rotate(new Vector3(rX, rY, rZ) * Time.deltaTime);
	}
}
