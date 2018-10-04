using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {


    Animator animator;
    GameObject sel;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        sel = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y > sel.transform.position.y)
        {
            animator.SetInteger("Direction", 3);
        }
        if (this.transform.position.y < sel.transform.position.y)
        {
            animator.SetInteger("Direction", 1);
        }
	}
}
