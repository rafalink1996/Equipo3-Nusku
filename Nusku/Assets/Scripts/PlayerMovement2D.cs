using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour {

    float speed; //variable interna para la velocidad. toma el valor de walkSpeed o de runSpeed
    bool diagonal; // determina si está en diagonal
    public float walkSpeed; // velocidad normal de caminar, el valor se pone en el inspector
    //public int direction = 5;
    Rigidbody rb;
    //public float jumpForce;
    //public bool isGrounded = true;
    Animator anim;
    Animator armAnim;
    //public float health;
    //public bool dead = false;
    //public AudioSource caminata;
    //public AudioSource salto;
    //public AudioSource muerte;
    //bool pause = false;
    //public bool attackReady = false;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        armAnim = this.transform.Find("Graphics/Arm").gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        //health = GetComponent<SliderTest>().sliderHealth.value;
        if (Input.GetAxisRaw("Horizontal") != 0){
            this.transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f);
            anim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            armAnim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.Translate(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f);
            anim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
            armAnim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
        }
        anim.SetFloat("DirectionX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("DirectionY", Input.GetAxisRaw("Vertical"));
        armAnim.SetFloat("DirectionX", Input.GetAxisRaw("Horizontal"));
        armAnim.SetFloat("DirectionY", Input.GetAxisRaw("Vertical"));
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") == 0){
            anim.SetFloat("LastY", 0f);
            armAnim.SetFloat("LastY", 0f);
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetFloat("LastX", 0f);
            armAnim.SetFloat("LastX", 0f);
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
            anim.SetBool("IsMoving", true);
            armAnim.SetBool("IsMoving", true);
        }else{
            anim.SetBool("IsMoving", false);
            armAnim.SetBool("IsMoving", false);
        }
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            diagonal = true; //determina si está moviéndose en una diagonal
        }
        else
        {
            diagonal = false;
        }
        if (diagonal == false)
        { // hace que la velocidad sea la normal
            speed = walkSpeed;
        }

        if (diagonal == true)
        { // ajusta la velocidad de caminada en las diagonales, para que no sea más rápido
            speed = Mathf.Sin(0.785398163397448f) * walkSpeed;
        }
        // /*if (Input.GetKeyDown(jump) && isGrounded == true /*&& dead == false*/)
        //{
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //    anim.SetBool("Jump", true);
        //    anim.SetBool("JumpButtonPressed", true);
        //    //anim.SetBool("Button", true);
        //}
        //if (Input.GetKey(attack) /*&& dead == false*/)
        //{
        //    anim.SetBool("Attack", true);
        //    anim.SetBool("AttackButton", true);
        //}
        //else
        //{
        //    anim.SetBool("Attack", false);
        //}
        //if (Input.GetKeyUp(attack) && isGrounded == false)
        //{
        //    anim.SetBool("AttackButton", false);
        //}

        //if (health <= 0)
        //{
        //    //dead = true;
        //    anim.SetBool("Dead", true);
        //    muerte.enabled = true;

        //}*/
        ////print("health ="+ health); 

        ///*if (Input.GetKey(up) && isGrounded == true && dead == false || Input.GetKey(down) && isGrounded == true /*&& dead == false || Input.GetKey(left) && isGrounded == true && dead == false || Input.GetKey(right) && isGrounded == true /*&& dead == false)
        //{
        //    caminata.volume = Random.Range(0.5f, 1);
        //    caminata.enabled = true;
        //}
        //else
        //{
        //    caminata.enabled = false;

        //}

        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true /*&& dead == false)
        //{
        //        salto.Play();
        //    }

        //}
        //void OnCollisionEnter(Collision collision)
        //{
        //if (collision.collider.gameObject.tag == "Ground")
        //{
        //    isGrounded = true;
        //    anim.SetBool("Jump", false);
        //    //anim.SetBool("Jumping", false);
        //    //anim.SetBool("JumpButtonPressed", false);
        //}
        /*if (collision.collider.gameObject.tag == "Enemy")
        {
            health = health - 10;
            
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGrounded = false;
            anim.SetBool("Jumping", true);
        }
        if (collision.collider.gameObject.tag != "Ground")
        {
            anim.SetBool("Jumping", false);
        }
    }
    void AttackButton()
    {
        anim.SetBool("AttackButton", false);

    }
    void Jumping()
    {
        anim.SetBool("Jumping", false);
    }
    void JumpButtonPressed()
    {
        anim.SetBool("JumpButtonPressed", false);
    }*/
    }
}