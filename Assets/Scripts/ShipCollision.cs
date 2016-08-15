using UnityEngine;
using System.Collections;

public class ShipCollision : MonoBehaviour {
    public bool isTopView;
    private bool isCollidable = false;
	
	private GameObject retry;

	// Use this for initialization
	void Start () {
		retry = GameObject.FindGameObjectWithTag("RetryTag");
		retry.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
        if (isTopView == RotateCamera.isTopView)
        {
            isCollidable = true;
        }
        else
        {
            isCollidable = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {

        System.Console.WriteLine("Collission Detected");
        if (isCollidable)
        {
            if (col.gameObject.name == "Asteroid(Clone)")
            {
				//Destroy(transform.parent.gameObject);
                Destroy(col.gameObject);
                System.Console.WriteLine("Delete Asteroid");

				// Pop up Retry menu
				retry.SetActive(true);
            }
        }
    }
}
