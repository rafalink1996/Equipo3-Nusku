using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	float speed; //variable interna para la velocidad. toma el valor de walkSpeed o de runSpeed
	bool diagonal; // determina si está en diagonal
	//bool isRunning = false; //determina si está corriendo
	public float walkSpeed; // velocidad normal de caminar, el valor se pone en el inspector
	//public float runSpeed; // velocidad de correr, el valor se pone en el inspector
	public string up; //estas variables nos dejan asignar la tecla desde el inspector
	public string down;
	public string right;
	public string left;
	public string run;
	public string jump;
	Rigidbody rb;
	public float jumpForce;
	bool isGrounded = true;
    Animator anim;

    void Start ()
	{
		rb = GetComponent<Rigidbody> ();
        anim = GetComponent<Animator>();

	}

	void Update ()
	{
        if (Input.GetKey(up) || Input.GetKey(down) || Input.GetKey(right) || Input.GetKey(left))
        {
            anim.SetBool("IsMoving", true); //Determina si se está presionando una tecla de movimiento para saber si se está moviendo y reproducir las respectivas animaciones
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
		if (Input.GetKey (up)) { //moverse hacia el norte
            transform.Translate(0, 0, speed * Time.deltaTime);
            anim.SetBool("North", true); //Determina si se está presionando una tecla de movimiento para saber si se está moviendo y reproducir las respectivas animaciones
            anim.SetBool("South", false);
            anim.SetBool("West", false);
            anim.SetBool("East", false);
            /* }else{
            anim.SetBool("North", false);*/
        }
        if (Input.GetKey (down)) { //moverse hacia el sur
			transform.Translate (0, 0, -speed * Time.deltaTime);
            anim.SetBool("South", true);
            anim.SetBool("North", false);
            anim.SetBool("West", false);
            anim.SetBool("East", false);
        /*}else{
            anim.SetBool("South", false);*/
        }
        if (Input.GetKey(right)) { //moverse hacia el este
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetBool("East", true);
            anim.SetBool("West", false);
            anim.SetBool("North", false);
            anim.SetBool("South", false);
            }
        /*}else{
            anim.SetBool("East", false);*/
		if (Input.GetKey (left)) { //moverse hacia el oeste
			transform.Translate (-speed * Time.deltaTime, 0, 0);
            anim.SetBool("West", true);
            anim.SetBool("North", false);
            anim.SetBool("South", false);
            anim.SetBool("East", false);
       /* }else{
            anim.SetBool("West", false);*/
        }
        if (Input.GetKey(up) && Input.GetKey(right)){
            anim.SetBool("West", false);
            anim.SetBool("North", true);
            anim.SetBool("South", false);
            anim.SetBool("East", true);
        }
        if (Input.GetKey(up) && Input.GetKey(left))
        {
            anim.SetBool("West", true);
            anim.SetBool("North", true);
            anim.SetBool("South", false);
            anim.SetBool("East", false);
        }
        if (Input.GetKey(down) && Input.GetKey(left))
        {
            anim.SetBool("West", true);
            anim.SetBool("North", false);
            anim.SetBool("South", true);
            anim.SetBool("East", false);
        }
        if (Input.GetKey(down) && Input.GetKey(right))
        {
            anim.SetBool("West", false);
            anim.SetBool("North", false);
            anim.SetBool("South", true);
            anim.SetBool("East", true);
        }
		/*if (Input.GetKey (run)) { //correr; aumenta la velocidad
			isRunning = true;
		} else {
			isRunning = false;
		}*/
		if (Input.GetKey (up) && Input.GetKey (right) || Input.GetKey (up) && Input.GetKey (left) || Input.GetKey (down) && Input.GetKey (right) || Input.GetKey (down) && Input.GetKey (left)) {
			diagonal = true; //determina si está moviéndose en una diagonal
		} else {
			diagonal = false;
		}
		if (/*isRunning == false && */diagonal == false) { // hace que la velocidad sea la normal
			speed = walkSpeed;
		}
		/*if (isRunning == true && diagonal == false) { // hace que la velocidad sea la de correr
			speed = runSpeed;
		}*/
		if (/*isRunning == false && */diagonal == true) { // ajusta la velocidad de caminada en las diagonales, para que no sea más rápido
			speed = Mathf.Sin (0.785398163397448f) * walkSpeed;
		}
		/*if (isRunning == true && diagonal == true) { //ajusta la velocidad de las diagonales al correr
			speed = Mathf.Sin (0.785398163397448f) * runSpeed;
		}*/
		if (Input.GetKeyDown (jump) && isGrounded == true) {
			rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("Jump", true);
        }
		print ("speed =" + speed);
	}
	void OnCollisionEnter (Collision collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = true;
            anim.SetBool("Jump", false);
		}
	}
	void OnCollisionExit (Collision collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}
}
