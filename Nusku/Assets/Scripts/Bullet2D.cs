﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet2D : MonoBehaviour {

    float speed = 10.0f;
    PlayerMovement2D sel;
   

    void Start()
    {
        sel = FindObjectOfType<PlayerMovement2D>();
    }

    void Update()
    {
        if (sel.canMove == false)
        {
            Destroy(this.gameObject);
        }
        if (transform.parent == null)
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            Destroy(this.gameObject, 1);
        }
        if (this.transform.parent != null){
            this.transform.position = this.transform.parent.position;
            if (Input.GetAxisRaw("Vertical") == 1){
                this.GetComponent<ParticleSystemRenderer>().sortingOrder = 4;
            }
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                this.GetComponent<ParticleSystemRenderer>().sortingOrder = 6;
            }
            if (Input.GetAxisRaw("Fire1") == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != "Player" && this.transform.parent == null)
        {
            Destroy(this.gameObject);
        }
    }
}
