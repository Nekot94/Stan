using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour 
{
    public Transform vrCamera;

    public float toggleAngle = 30;
    public float speed = 3;

    public bool moveForvard;
    
    Rigidbody myBody;

	void Start ()
	{
        myBody = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
	{
        moveForvard = vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x <= 90 ? true : false;

        if (moveForvard)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            myBody.velocity = forward * speed;
        }

    }
}
