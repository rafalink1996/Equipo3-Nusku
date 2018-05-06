using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	float speed = 0; //variable interna para la velocidad. toma el valor de walkSpeed o de runSpeed
	bool diagonal = false; // determina si está en diagonal
	bool isRunning = false; //determina si está corriendo
	public float walkSpeed; // velocidad normal de caminar, el valor se pone en el inspector
	public float runSpeed; // velocidad de correr, el valor se pone en el inspector
	public string up; //estas variables nos dejan asignar la tecla desde el inspector
	public string down;
	public string right;
	public string left;
	public string run;
	public string jump;
	private Rigidbody rb;
	public float jumpForce;
	bool isGrounded = true;


	// Temporal
	//PlayerAnimations playeranims;

	//GameObject rigo;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();

		//GameObject rigo = this.transform.Find ("padre/hijoA/player/animations");

		//rigo.GetComponent<PlayerAnimations> ().movingUp ();
	}

	void Update ()
	{
		if (Input.GetKey (up)) { //moverse hacia el norte
            transform.Translate(0, 0, speed * Time.deltaTime);
			//this.gameObject.GetComponent<PlayerAnimations> ().animatorMoving (true);
        }
        if (Input.GetKey (down)) { //moverse hacia el sur
			transform.Translate (0, 0, -speed * Time.deltaTime);
			//this.gameObject.GetComponent<PlayerAnimations> ().animatorMoving (false);
		}
		if (Input.GetKey (right)) { //moverse hacia el este
			transform.Translate (speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (left)) { //moverse hacia el oeste
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (run)) { //correr; aumenta la velocidad
			isRunning = true;
		} else {
			isRunning = false;
		}
		if (Input.GetKey (up) && Input.GetKey (right) || Input.GetKey (up) && Input.GetKey (left) || Input.GetKey (down) && Input.GetKey (right) || Input.GetKey (down) && Input.GetKey (left)) {
			diagonal = true; //determina si está moviéndose en una diagonal
		} else {
			diagonal = false;
		}
		if (isRunning == false && diagonal == false) { // hace que la velocidad sea la normal
			speed = walkSpeed;
		}
		if (isRunning == true && diagonal == false) { // hace que la velocidad sea la de correr
			speed = runSpeed;
		}
		if (isRunning == false && diagonal == true) { // ajusta la velocidad de caminada en las diagonales, para que no sea más rápido
			speed = Mathf.Sin (0.785398163397448f) * walkSpeed;
		}
		if (isRunning == true && diagonal == true) { //ajusta la velocidad de las diagonales al correr
			speed = Mathf.Sin (0.785398163397448f) * runSpeed;
		}
		if (Input.GetKeyDown (jump) && isGrounded == true) {
			rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
			//isGrounded = false;
		}
		print ("speed =" + speed);
	}
	void OnCollisionEnter (Collision collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}
	void OnCollisionExit (Collision collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}
}
