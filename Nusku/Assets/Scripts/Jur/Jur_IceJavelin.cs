using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur_IceJavelin : MonoBehaviour {

    public float speed;
    Animator anim;
    public int damage;
    SelHealth sel;
	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        Destroy(this.gameObject, 2);
        sel = FindObjectOfType<SelHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name != "Jur" && collision.collider.name != "IceJavelin")
        {
            anim.SetTrigger("Crash");
            speed = 0;
            Destroy(gameObject, 0.3f);
        }
        if (collision.collider.tag == "Player")
        {
            sel.TakeDamage(damage);
        }
    }

}
