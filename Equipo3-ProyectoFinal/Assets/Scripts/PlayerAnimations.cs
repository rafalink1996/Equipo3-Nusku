using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {
	
	Animator anim;
	private PlayerMovement playerMovement;

	void Start () {
		anim = GetComponent<Animator> ();
		playerMovement = GetComponent<PlayerMovement> ();
	}

	void FixedUpdate () {
		if (Input.GetKey (playerMovement.up) || Input.GetKey (playerMovement.down) || Input.GetKey (playerMovement.right) || Input.GetKey (playerMovement.left)) {
			anim.SetBool ("IsMoving", true);
		} else {
			anim.SetBool ("IsMoving", false);
		}
		if (Input.GetKey (playerMovement.up)) {
			anim.SetInteger ("Direction", 1);
		}
		if (Input.GetKey (playerMovement.right) && Input.GetKey (playerMovement.up)) {
			anim.SetInteger ("Direction", 2);
		}
		if (Input.GetKey (playerMovement.right)){
			anim.SetInteger ("Direction", 3);
		}
		if (Input.GetKey (playerMovement.right) && Input.GetKey (playerMovement.down)) {
			anim.SetInteger ("Direction", 4);
		}
		if (Input.GetKey (playerMovement.down)) {
			anim.SetInteger ("Direction", 5);
		}
		if (Input.GetKey (playerMovement.left) && Input.GetKey (playerMovement.down)) {
			anim.SetInteger ("Direction", 6);
		}
		if (Input.GetKey (playerMovement.left)) {
			anim.SetInteger ("Direction", 7);
		}
		if (Input.GetKey (playerMovement.left) && Input.GetKey (playerMovement.up)) {
			anim.SetInteger ("Direction", 8);
		}
	}
}
