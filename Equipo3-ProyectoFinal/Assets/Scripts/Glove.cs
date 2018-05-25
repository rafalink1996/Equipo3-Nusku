using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour {

    int sel;
    string attack;
    bool dead;
    public bool oneSecInProgress = false;
    public bool attacking = false;
    public AudioSource powerup;
    public AudioSource shoot;


    void Start () {
        attack = GameObject.Find("Sel").GetComponent<PlayerMovement>().attack;
	}

    // Update is called once per frame
    void Update()
    {
        sel = GameObject.Find("Sel").GetComponent<PlayerMovement>().direction;
        dead = GameObject.Find("Sel").GetComponent<PlayerMovement>().dead;
        if (sel == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 270, 0);
            this.transform.localPosition = new Vector3(-0.21f, 0, 0.38f);
        }
        if (sel == 2)
        {
            this.transform.rotation = Quaternion.Euler(0, 315, 0);
            this.transform.localPosition = new Vector3(0.34f, 0f, 0.38f);
        }
        if (sel == 3)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.transform.localPosition = new Vector3(0.59f, 0.16f, -0.38f);
        }
        if (sel == 4)
        {
            this.transform.rotation = Quaternion.Euler(0, 45, 0);
            this.transform.localPosition = new Vector3(0.68f, 0.04f, -0.38f);
        }
        if (sel == 5)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
            this.transform.localPosition = new Vector3(0.34f, 0.04f, -0.38f);
        }
        if (sel == 6)
        {
            this.transform.rotation = Quaternion.Euler(0, 135, 0);
            this.transform.localPosition = new Vector3(-0.45f, -0.11f, -0.38f);
        }
        if (sel == 7)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            this.transform.localPosition = new Vector3(-0.54f, 0.09f, -0.38f);
        }
        if (sel == 8)
        {
            this.transform.rotation = Quaternion.Euler(0, 225, 0);
            this.transform.localPosition = new Vector3(-0.64f, 0.16f, 0.38f);
        }
        //attackReady = GameObject.Find("Sel").GetComponent<PlayerMovement>().attackReady;


        // El usuario no esta atacando, ni hay presionado la tecla, ni el segundo ha transucrrido
        if(Input.GetKeyDown(attack) && oneSecInProgress == false) {
            oneSecInProgress = true;

            powerup.Play();
           



            // Agendo la funcion de terminacion
            Invoke("OneSecondAfter", 1.0f);
        }

        if (Input.GetKeyUp(attack))
        {
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

                   
                    shoot.Play();

                }
            }
        }

    }

    public void OneSecondAfter() {
        

        if (Input.GetKey(attack)) { 

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
