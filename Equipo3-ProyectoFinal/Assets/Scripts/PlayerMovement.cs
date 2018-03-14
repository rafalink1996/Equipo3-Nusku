using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	float speed;
	public bool diagonal = false;
	public bool isRunning = false;
	public float walkSpeed;
	public float runSpeed;
	public string up;
	public string down;
	public string right;
	public string left;
	public string run;
	//public string jump;


	void Start ()
	{

	}

	void FixedUpdate ()
	{
		if (Input.GetKey (up)) {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey (down)) {
			transform.Translate (0, 0, -speed * Time.deltaTime);
		}
		if (Input.GetKey (right)) {
			transform.Translate (speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (left)) {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (run)) {
			isRunning = true;
		} else {
			isRunning = false;
		}
		if (Input.GetKey (up) && Input.GetKey (right) || Input.GetKey (up) && Input.GetKey (left) || Input.GetKey (down) && Input.GetKey (right) || Input.GetKey (down) && Input.GetKey (left)) {
			diagonal = true;
		} else {
			diagonal = false;
		}
		if (isRunning == false && diagonal == false) {
			speed = walkSpeed;
		}
		if (isRunning == true && diagonal == false) {
			speed = runSpeed;
		}
		if (isRunning == false && diagonal == true) {
			speed = Mathf.Sin (0.785398163397448f) * walkSpeed;
		}
		if (isRunning == true && diagonal == true) {
			speed = Mathf.Sin (0.785398163397448f) * runSpeed;
		}
		Debug.LogFormat ("speed = {0}", speed);
		/*if (Input.GetKeyDown (jump)){
			Rigidbody.AddForce*/
	}
}
