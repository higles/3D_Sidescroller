using UnityEngine;
using System.Collections;
using System;

public class MoveShip : MonoBehaviour {
    private Transform ship;
    private Rigidbody rb;
    
    private float dxRange = 8.5f;
    private float dyRange = 8.5f;
    
    public float speed;
    public float tilt;

	// Use this for initialization
	void Start () {
        ship = this.gameObject.transform;
        rb = ship.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Vertical");

        Vector3 movement;
        if (RotateCamera.isTopView)
        {
            movement = new Vector3(-move, 0, 0);
            rb.velocity = movement * speed;
            rb.position = new Vector3(Mathf.Clamp(rb.position.x, -dxRange, dxRange), rb.position.y, rb.position.z);
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
            ship.Find("VCollidable").rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else
        {
            movement = new Vector3(0, move, 0);
            rb.velocity = movement * speed;
            rb.position = new Vector3(rb.position.x, Mathf.Clamp(rb.position.y, -dyRange, dyRange), rb.position.z);
            rb.rotation = Quaternion.Euler(rb.velocity.y * -tilt * 0.5f, 0.0f, 0.0f);
        }
    }
}
