using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLoad : MonoBehaviour {

    PlayerMovement2D sel;
    Animator selAnim;
	
	void Start () {
        sel = FindObjectOfType<PlayerMovement2D>();
        selAnim = GameObject.Find("Sel/Graphics").GetComponent<Animator>();
	}
	
	
	void Update () {
        if (sel.canMove == false)
        {
            Destroy(this.gameObject);
        }
        this.transform.position = this.transform.parent.position;
        if (selAnim.GetFloat("LastY") == 1)
        {
            this.GetComponent<ParticleSystemRenderer>().sortingOrder = 4;
        }
        if (selAnim.GetFloat("LastY") == -1)
        {
            this.GetComponent<ParticleSystemRenderer>().sortingOrder = 6;
        }
	}
}
