using UnityEngine;
using System.Collections;
using System;

public class MoveShip : MonoBehaviour {
    public Camera camera;
    private Transform ship;
    private Rigidbody rb;

    private bool isTopView;
    private bool outOfBounds = false;
    private float dx = 0;
    private float dy = 0;
    private float rx = 0;
    private float rz = 0;
    private float dxRange = 8.5f;
    private float dyRange = 8.5f;
    private float rxRange = 20f;
    private float rzRange = 20f;

    public float dDELTA;
    private float rDELTA = 20f;
    public float speed;
    public float tilt;

	// Use this for initialization
	void Start () {
        ship = this.gameObject.transform;
        rb = ship.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        isTopView = false;
        if (camera.transform.position.y > 2f)
        {
            isTopView = true;
        }

        float move = Input.GetAxis("Vertical");

        Vector3 movement;
        if (isTopView)
        {
            movement = new Vector3(-move, 0, 0);
            rb.velocity = movement * speed;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, -dxRange, dxRange), 0.0f, 0.0f);
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
            ship.Find("VCollidable").rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else
        {
            movement = new Vector3(0, move, 0);
            rb.velocity = movement * speed;
            rb.position = new Vector3(0.0f, Mathf.Clamp(rb.position.y, -dyRange, dyRange), 0.0f);
            rb.rotation = Quaternion.Euler(rb.velocity.y * -tilt * 0.5f, 0.0f, 0.0f);
        }

        ////Get direction to move ship
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //{
        //    if (isTopView)
        //    {
        //        dx = -dDELTA;
        //        rz = -rDELTA;
        //    }
        //    else
        //    {
        //        dy = dDELTA;
        //        rx = -rDELTA;
        //    }
        //}
        //else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    if (isTopView)
        //    {
        //        dx = dDELTA;
        //        rz = rDELTA;
        //    }
        //    else
        //    {
        //        dy = -dDELTA;
        //        rx = rDELTA;
        //    }
        //}

        ////Check bounds
        //if (Math.Abs(ship.position.x + dx) > dxRange)
        //{
        //    float polarity = (ship.position.x + dx) / Math.Abs(ship.position.x + dx);
        //    ship.position.Set(dxRange * polarity, ship.position.y, ship.position.z);
        //    outOfBounds = true;
        //}
        //if (Math.Abs(ship.position.y + dy) > dxRange)
        //{
        //    float polarity = (ship.position.y + dy) / Math.Abs(ship.position.y + dy);
        //    ship.position.Set(ship.position.x, dyRange * polarity, ship.position.z);
        //    outOfBounds = true;
        //}

        //if (!outOfBounds)
        //{   //if ship is in bounds after move, then move it.
        //    ship.Translate(new Vector3(dx, dy, 0) * Time.deltaTime);
        //    ship.Rotate(new Vector3(rx, 0, rz) * Time.deltaTime);
        //}

        ////Reset values
        //outOfBounds = false;
        //dx = 0;
        //dy = 0;
        //rx = 0;
        //rz = 0;
    }
}
