using UnityEngine;
using System.Collections;

public class SpawnAsteroids : MonoBehaviour {
    public float modifier;
    public Transform asteroid;

    private float x, y, z, rotX, rotY, rotZ;

	// Use this for initialization
	void Start () {
        z = 45;
	}
	
	// Update is called once per frame
	void Update () {
        if (Random.Range(0, 100) * modifier > 98)
        {
            //Get starting position
            x = Random.Range(-8.5f, 8.5f);
            y = Random.Range(-8.5f, 8.5f);

            //Get starting rotation
            rotX = Random.Range(-180, 180);
            rotY = Random.Range(-180, 180);
            rotZ = Random.Range(-180, 180);

            //Set position and rotation
            asteroid.position.Set(x, y, z);
            asteroid.rotation.Set(rotX, rotY, rotZ, 1);

            Instantiate(asteroid, new Vector3(x, y, z), Quaternion.identity);
        }
	}
}
