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

	void Update () {
		if (Input.GetKey (playerMovement.up) || Input.GetKey (playerMovement.down) || Input.GetKey (playerMovement.right) || Input.GetKey (playerMovement.left)) {
			anim.SetBool ("IsMoving", true);
		} else {
			anim.SetBool ("IsMoving", false);
		}
		if (Input.GetKeyDown (playerMovement.up)) {
			anim.SetBool ("North", true);
			//print ("Direction = 1");
		}
		if (Input.GetKeyUp (playerMovement.up)) {
			anim.SetBool ("North", false);
		}
		/*if (Input.GetKey (playerMovement.right) && Input.GetKey (playerMovement.up)) {
			anim.SetInteger ("Direction", 2);
			print ("Direction = 2");
		}*/
		if (Input.GetKey (playerMovement.right)){
			anim.SetBool ("East", true);
			//print ("Direction = 3");
		}
		if (Input.GetKeyUp (playerMovement.right)) {
			anim.SetBool ("East", false);
		}
		/*if (Input.GetKey (playerMovement.right) && Input.GetKey (playerMovement.down)) {
			anim.SetInteger ("Direction", 4);
			print ("Direction = 4");
		}*/
		if (Input.GetKey (playerMovement.down)) {
			anim.SetBool ("South", true);
			//print ("Direction = 5");
		}
		if (Input.GetKeyUp (playerMovement.down)) {
			anim.SetBool ("South", false);
		}
		/*if (Input.GetKey (playerMovement.left) && Input.GetKey (playerMovement.down)) {
			anim.SetInteger ("Direction", 6);
			print ("Direction = 6");
		}*/
		if (Input.GetKey (playerMovement.left)) {
			anim.SetBool ("West", true);
			//print ("Direction = 7");
		}
		if (Input.GetKeyUp (playerMovement.left)) {
			anim.SetBool ("West", false);
		}
		/*if (Input.GetKey (playerMovement.left) && Input.GetKey (playerMovement.up)) {
			anim.SetInteger ("Direction", 8);
			print ("Direction = 8");
		}*/
	}
}
