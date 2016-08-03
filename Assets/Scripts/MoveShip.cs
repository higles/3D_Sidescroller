using UnityEngine;
using System.Collections;
using System;

public class MoveShip : MonoBehaviour {
    public Camera camera;
    private Transform ship;

    private bool isTopView;
    private bool outOfBounds = false;
    private float dx = 0;
    private float dy = 0;
    private float xRange = 8.5f;
    private float yRange = 8.5f;

    public float DELTA;

	// Use this for initialization
	void Start () {
        ship = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
        isTopView = false;
        if (camera.transform.position.y > 2f)
        {
            isTopView = true;
        }

        //Get direction to move ship
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (isTopView)
            {
                dx = -DELTA;
            }
            else
            {
                dy = DELTA;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (isTopView)
            {
                dx = DELTA;
            }
            else
            {
                dy = -DELTA;
            }
        }

        //Check bounds
        if (Math.Abs(ship.position.x + dx) > xRange)
        {
            float polarity = (ship.position.x + dx) / Math.Abs(ship.position.x + dx);
            ship.position.Set(xRange * polarity, ship.position.y, ship.position.z);
            outOfBounds = true;
        }
        if (Math.Abs(ship.position.y + dy) > xRange)
        {
            float polarity = (ship.position.y + dy) / Math.Abs(ship.position.y + dy);
            ship.position.Set(ship.position.x, yRange * polarity, ship.position.z);
            outOfBounds = true;
        }
        
        if (!outOfBounds)
        {   //if ship is in bounds after move, then move it.
            ship.Translate(new Vector3(dx, dy, 0));
        }

        //Reset values
        outOfBounds = false;
        dx = 0;
        dy = 0;
    }
}
