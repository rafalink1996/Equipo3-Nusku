using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur2D : MonoBehaviour {

    float timeToAttack;
    Animator anim;
    bool isAttacking = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        timeToAttack = Random.Range(1.0f, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
        timeToAttack -= Time.deltaTime;
        if (timeToAttack <= 0 && isAttacking == false){
            anim.SetFloat("attackType", Random.Range(0, 3));
            anim.SetTrigger("Attack");
            isAttacking = true;
            anim.SetBool("isAttacking", true);
        }

	}
    void resetTimer (){
        timeToAttack = Random.Range(1.0f, 4.0f);
        isAttacking = false;
        anim.SetBool("isAttacking", false);
    }
}
