﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur_Bullet : MonoBehaviour {

    public float speed;
    public int damage;
    SelHealth sel;
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        Destroy(this.gameObject, 4);
        sel = FindObjectOfType<SelHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Mathf.Cos(0.523598775f) * speed * Time.deltaTime, Mathf.Sin(0.523598775f) * -speed * Time.deltaTime, 0);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Bullet" && collision.collider.name != "Jur" && collision.collider.name != "Jur_Bullet" && collision.collider.tag != "Object")
        {
            animator.SetTrigger("Crash");
            speed = 0;
        }
        if (collision.collider.tag == "Stalactite")
        {
            collision.collider.GetComponent<Animator>().SetTrigger("Destroy");
            collision.transform.Find("StalactiteTop").gameObject.SetActive(false);
        }
        if (collision.collider.tag == "Player")
        {
            sel.TakeDamage(damage);
        }
    }
    void Crash ()
    {
        Destroy(this.gameObject);
    }
}
