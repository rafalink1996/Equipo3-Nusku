using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove2D : MonoBehaviour {

    int sel;
    bool dead;
    bool oneSecInProgress = false;
    bool attacking = false;
    PlayerMovement2D player;
    public AudioClip shoot;
    public bool hasGlove = true;


    void Start()
    {
        player = FindObjectOfType<PlayerMovement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.canMove || !hasGlove)
        {
            
            return;
        }
        //sel = GameObject.Find("Sel").GetComponent<PlayerMovement>().direction;
        //dead = GameObject.Find("Sel").GetComponent<PlayerMovement>().dead;
        if (player.anim.GetFloat("LastX") == 0 && player.anim.GetFloat("LastY") == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
            this.transform.localPosition = new Vector3(-0.133f, 0, 0);
        }
        if (player.anim.GetFloat("LastX") == 1 && player.anim.GetFloat("LastY") == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 30);
            this.transform.localPosition = new Vector3(0.317f, -0.046f, 0);
        }
        if (player.anim.GetFloat("LastX") == 1 && player.anim.GetFloat("LastY") == 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.transform.localPosition = new Vector3(0.248f, 0f, 0f);
        }
        if (player.anim.GetFloat("LastX") == 1 && player.anim.GetFloat("LastY") == -1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, -30);
            this.transform.localPosition = new Vector3(0.184f, -0.075f, 0f);
        }
        if (player.anim.GetFloat("LastX") == 0 && player.anim.GetFloat("LastY") == -1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 270);
            this.transform.localPosition = new Vector3(0.155f, -0.072f, 0f);
        }
        if (player.anim.GetFloat("LastX") == -1 && player.anim.GetFloat("LastY") == -1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, -150);
            this.transform.localPosition = new Vector3(-0.278f, -0.075f, 0f);
        }
        if (player.anim.GetFloat("LastX") == -1 && player.anim.GetFloat("LastY") == 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
            this.transform.localPosition = new Vector3(-0.261f, 0f, 0f);
        }
        if (player.anim.GetFloat("LastX") == -1 && player.anim.GetFloat("LastY") == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 150);
            this.transform.localPosition = new Vector3(-0.283f, -0.063f, 0f);
        }
        //attackReady = GameObject.Find("Sel").GetComponent<PlayerMovement>().attackReady;


        // El usuario no esta atacando, ni hay presionado la tecla, ni el segundo ha transucrrido
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject attackLoad = GameObject.Instantiate(Resources.Load("Prefabs/AttackLoad") as GameObject);
            attackLoad.name = "AttackLoad";
            attackLoad.transform.SetParent(this.gameObject.transform);
            attackLoad.transform.localPosition = new Vector3(0, 0, 0);
            if (oneSecInProgress == false)
            {
                oneSecInProgress = true;

                //powerup.Play();
            }



            // Agendo la funcion de terminacion
            Invoke("OneSecondAfter", 0.5f);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            GameObject attackLoad = GameObject.Find("AttackLoad");
            Destroy(attackLoad);
            if (oneSecInProgress == true)
            {
                // No pasa nada, porque queremos evitar que presiona la tecla repetidas veces
                CancelInvoke("OneSecondAfter");
                oneSecInProgress = false;

            }
            else
            {
                if (oneSecInProgress == false)
                {
                    // Dispara la bolita
                    // Esta accion la realiza un script en la bolita
                    GameObject bullet = GameObject.Find("Bullet");
                    bullet.transform.SetParent(null);
                    GetComponent<AudioSource>().PlayOneShot(shoot, 1);

                }
            }
        }

    }

    public void OneSecondAfter()
    {


        if (Input.GetButton("Fire1"))
        {

            // Comienza la creacion de la bolita, poque ya transcurrio un segundo
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
            bullet.name = "Bullet";
            bullet.transform.SetParent(this.gameObject.transform);
            bullet.transform.localPosition = new Vector3(0, 0, 0);
            bullet.transform.rotation = this.gameObject.transform.rotation;
            oneSecInProgress = false;
        }
    }
}