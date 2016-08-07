using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {
    public float speed;

    private Transform camera;
    public static bool isTopView;
    private bool isRotating = false;
    private float rotated = 0;

    private Vector3 point = new Vector3(0, 0, 15);

	// Use this for initialization
	void Start () {
        camera = this.gameObject.transform;

        isTopView = false;
        if (camera.position.y > 2)
        {
            isTopView = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //Rotate camera when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !isRotating)
        {
            isRotating = true;
            rotated = 0;
        }
        if (isRotating)
        { 
            if (isTopView)
            {
                //Rotate to side view
                RotateAroundPoint(-90);
            }
            else
            {
                //Rotate to top view
                RotateAroundPoint(90);
            }
        }
	}

    // Rotates the camera the correct amount/direction
    void RotateAroundPoint(float rotation)
    {
        rotated += rotation * Time.deltaTime * speed;

        if (Mathf.Abs(rotated) > Mathf.Abs(rotation))
        {
            camera.RotateAround(point, new Vector3(0, 0, 1), (rotation * Time.deltaTime * speed) - (rotated - rotation));
            isRotating = false;
            isTopView = !isTopView;
        }
        else
        {
            camera.RotateAround(point, new Vector3(0, 0, 1), rotation * Time.deltaTime * speed);
        }
    }
}
