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
	//public string run;
	public string jump;
    public string attack;
    public int direction = 5;
	Rigidbody rb;
	public float jumpForce;
	bool isGrounded = true;
    Animator anim;
    int health = 100;
    public bool dead = false;
    public AudioSource caminata;
    public AudioSource salto;
    public AudioSource muerte;





    //public bool attackReady = false;

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
        if (Input.GetKey (up) && dead == false) { //moverse hacia el norte
            transform.Translate(0, 0, speed * Time.deltaTime);
            anim.SetBool("North", true); //Determina si se está presionando una tecla de movimiento para saber si se está moviendo y reproducir las respectivas animaciones
            anim.SetBool("South", false);
            anim.SetBool("West", false);
            anim.SetBool("East", false);
            direction = 1;
        }
        if (Input.GetKey (down) && dead == false) { //moverse hacia el sur
			transform.Translate (0, 0, -speed * Time.deltaTime);
            anim.SetBool("South", true);
            anim.SetBool("North", false);
            anim.SetBool("West", false);
            anim.SetBool("East", false);
            direction = 5;
        }
        if (Input.GetKey(right) && dead == false) { //moverse hacia el este
            transform.Translate(speed * Time.deltaTime, 0, 0);
            anim.SetBool("East", true);
            anim.SetBool("West", false);
            anim.SetBool("North", false);
            anim.SetBool("South", false);
            direction = 3;
            }
        if (Input.GetKey (left) && dead == false) { //moverse hacia el oeste
			transform.Translate (-speed * Time.deltaTime, 0, 0);
            anim.SetBool("West", true);
            anim.SetBool("North", false);
            anim.SetBool("South", false);
            anim.SetBool("East", false);
            direction = 7;
        }
        if (Input.GetKey(up) && Input.GetKey(right) && dead == false){
            anim.SetBool("West", false);
            anim.SetBool("North", true);
            anim.SetBool("South", false);
            anim.SetBool("East", true);
            direction = 2;
        }
        if (Input.GetKey(up) && Input.GetKey(left) && dead == false)
        {
            anim.SetBool("West", true);
            anim.SetBool("North", true);
            anim.SetBool("South", false);
            anim.SetBool("East", false);
            direction = 8;
        }
        if (Input.GetKey(down) && Input.GetKey(left) && dead == false)
        {
            anim.SetBool("West", true);
            anim.SetBool("North", false);
            anim.SetBool("South", true);
            anim.SetBool("East", false);
            direction = 6;
        }
        if (Input.GetKey(down) && Input.GetKey(right) && dead == false)
        {
            anim.SetBool("West", false);
            anim.SetBool("North", false);
            anim.SetBool("South", true);
            anim.SetBool("East", true);
            direction = 4;
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
        if (Input.GetKeyDown (jump) && isGrounded == true && dead == false) {
			rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("Jump", true);
            anim.SetBool("JumpButtonPressed", true);

            //anim.SetBool("Button", true);
        }
        if (Input.GetKey(attack) && dead == false){
            anim.SetBool("Attack", true);
            anim.SetBool("AttackButton", true);
        }else{
            anim.SetBool("Attack", false);
        }
        if (Input.GetKeyUp(attack) && isGrounded == false){
            anim.SetBool("AttackButton", false);
        }
       
        if (health <= 0){
            dead = true;
            anim.SetBool("Dead", true);
            muerte.enabled = true;

        }
        //print("health ="+ health); 

        if (Input.GetKey(up) && isGrounded == true && dead == false || Input.GetKey(down) && isGrounded == true && dead == false || Input.GetKey(left) && isGrounded == true && dead == false || Input.GetKey(right) && isGrounded == true && dead == false)
        {
            caminata.volume = Random.Range(0.5f, 1);
            caminata.enabled = true;
        }
        else
        {
            caminata.enabled = false;

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && dead == false)
        {
            salto.Play();
        }
    }
	void OnCollisionEnter (Collision collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = true;
            anim.SetBool("Jump", false);
            //anim.SetBool("Jumping", false);
            //anim.SetBool("JumpButtonPressed", false);
		}
        if (collision.collider.gameObject.tag == "Enemy")
        {
            health = health - 10;
            
        }
	}
	void OnCollisionExit (Collision collision) {
		if (collision.collider.gameObject.tag == "Ground") {
			isGrounded = false;
            anim.SetBool("Jumping", true);
		}
        if (collision.collider.gameObject.tag == "Object"){
            anim.SetBool("Jumping", false);
        }
	}
    void AttackButton (){
        anim.SetBool("AttackButton", false);

    }
    void Jumping(){
        anim.SetBool("Jumping", false);
    }
    void JumpButtonPressed(){
        anim.SetBool("JumpButtonPressed", false);
    }
   
}