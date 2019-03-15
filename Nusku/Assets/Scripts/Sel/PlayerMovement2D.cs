using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement2D : MonoBehaviour {

    float speedX; //variable interna para la velocidad. toma el valor de walkSpeed
    float speedY;
    bool diagonal; // determina si está en diagonal
    public float walkSpeed; // velocidad normal de caminar, el valor se pone en el inspector
    Rigidbody rb;
    public Animator anim;
    Animator armAnim;
    public AudioSource caminata;
    //public AudioSource salto;
    //public AudioSource muerte;
    bool pause = false;
    public bool canMove = true;
    public GameObject HUD;
    AudioSource pauseSound;
    public AudioClip pauseClip;
    Text paused;

  
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        armAnim = this.transform.Find("Graphics/Arm").gameObject.GetComponent<Animator>();
        transform.position = GameStats.stats.position;
        anim.SetFloat("LastX", GameStats.stats.selDirectionX);
        anim.SetFloat("LastY", GameStats.stats.selDirectionY);
        pauseSound = GetComponent<AudioSource>();
        paused = GameObject.Find("Canvas/Paused").GetComponent<Text>();

    }
    void Update()
    {
        armAnim.SetFloat("LastX", anim.GetFloat("LastX"));
        armAnim.SetFloat("LastY", anim.GetFloat("LastY"));
        if (Input.GetButtonDown("Pause"))
        {
            if (canMove && Time.timeScale == 1.0f && !pause)
            {
                Time.timeScale = 0;
                pause = true;
                AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
                foreach (AudioSource aud in audios)
                    aud.volume = 0;
                pauseSound.volume = 1;
                pauseSound.PlayOneShot(pauseClip);
                paused.enabled = true;
            }else{
                Time.timeScale = 1;
                pause = false;
                AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
                foreach (AudioSource aud in audios)
                    aud.volume = 1;
                pauseSound.PlayOneShot(pauseClip);
                paused.enabled = false;
            }
  
        }
        if (pause){
            return;
        }
        if (!canMove){
            anim.SetBool("IsMoving",false);
            armAnim.SetBool("IsMoving",false);
            armAnim.SetBool("Attack",false);
            HUD.SetActive(false);
            caminata.enabled = false;
            return;
        }else{
            HUD.SetActive(true);
        }
        //health = GetComponent<SliderTest>().sliderHealth.value;
        if (Input.GetAxisRaw("Horizontal") != 0){
            this.transform.Translate(Input.GetAxisRaw("Horizontal") * speedX * Time.deltaTime, 0f, 0f);
            anim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            armAnim.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            caminata.enabled = true;
            caminata.volume = 0.3f;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            this.transform.Translate(0f, Input.GetAxisRaw("Vertical") * speedY * Time.deltaTime, 0f);
            anim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
            armAnim.SetFloat("LastY", Input.GetAxisRaw("Vertical"));
            caminata.enabled = true;
            caminata.volume = 0.3f;
        }
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            caminata.enabled = false;
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
        if (Input.GetAxisRaw("Fire1") == 1){
            armAnim.SetBool("Attack",true);
        }else{
            armAnim.SetBool("Attack", false);
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
            speedX = walkSpeed;
            speedY = walkSpeed;
        }

        if (diagonal == true)
        { // ajusta la velocidad de caminada en las diagonales, para que no sea más rápido
            speedX = Mathf.Cos(0.523598775f) * walkSpeed;
            speedY = Mathf.Sin(0.523598775f) * walkSpeed;
        }



    }
}