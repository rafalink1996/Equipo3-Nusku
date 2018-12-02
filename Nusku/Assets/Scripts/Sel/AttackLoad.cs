using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLoad : MonoBehaviour {

    PlayerMovement2D sel;
    Animator selAnim;
    SpriteRenderer body;
	
	void Start () {
        sel = FindObjectOfType<PlayerMovement2D>();
        selAnim = GameObject.Find("Sel/Graphics").GetComponent<Animator>();
        body = GameObject.Find("Sel/Graphics").GetComponent<SpriteRenderer>();
	}
	
	
	void Update () {
        if (sel.canMove == false)
        {
            Destroy(this.gameObject);
        }
        this.transform.position = this.transform.parent.position;
        if (selAnim.GetFloat("LastY") == 1)
        {
            this.GetComponent<ParticleSystemRenderer>().sortingOrder = body.sortingOrder - 1;
        }
        if (selAnim.GetFloat("LastY") == -1)
        {
            this.GetComponent<ParticleSystemRenderer>().sortingOrder = body .sortingOrder + 2;
        }
	}
}
