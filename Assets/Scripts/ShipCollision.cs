using UnityEngine;
using System.Collections;

public class ShipCollision : MonoBehaviour {
    public bool isTopView;
    private bool isCollidable = false;
	// Use this for initialization
	void Start () {
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
                //Destroy(GameObject.Find("ship"));
                Destroy(col.gameObject);
                System.Console.WriteLine("Delete Asteroid");
            }
        }
    }
}
