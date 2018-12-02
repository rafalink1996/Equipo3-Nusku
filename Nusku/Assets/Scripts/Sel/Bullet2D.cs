using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet2D : MonoBehaviour {

    float speed = 10.0f;
    PlayerMovement2D sel;
    Animator selAnim;
    public AudioClip charge;
    SpriteRenderer body;

    void Start()
    {
        sel = FindObjectOfType<PlayerMovement2D>();
        selAnim = GameObject.Find("Sel/Graphics").GetComponent<Animator>();
        GetComponent<AudioSource>().PlayOneShot(charge, 4);
        body = GameObject.Find("Sel/Graphics").GetComponent<SpriteRenderer>();
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
            if (selAnim.GetFloat("LastY") == 1){
                this.GetComponent<ParticleSystemRenderer>().sortingOrder = body.sortingOrder - 1;
            }
            if (selAnim.GetFloat("LastY") == -1)
            {
                this.GetComponent<ParticleSystemRenderer>().sortingOrder = body.sortingOrder + 2;
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
