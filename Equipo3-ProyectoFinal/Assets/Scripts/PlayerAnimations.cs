using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {
	
	Animator anim;
	private PlayerMovement playerMovement; 

	void Start () {
		anim = GetComponent<Animator> ();
		playerMovement = GetComponent<PlayerMovement> (); //Llamamos al script de movimiento para poder usar sus variables
	}

	// Temporal
	//public void animatorMoving(bool newState){
		//anim.SetBool ("IsMoving", newState);
	//} 
	void Update () {
		if (Input.GetKey (playerMovement.up) || Input.GetKey (playerMovement.down) || Input.GetKey (playerMovement.right) || Input.GetKey (playerMovement.left)) {
			anim.SetBool ("IsMoving", true); //Determina si se está presionando una tecla de movimiento para saber si se está moviendo y reproducir las respectivas animaciones
		} else {
			anim.SetBool ("IsMoving", false);
		}
		if (Input.GetKey (playerMovement.up)) { //playerMovement.up significa que se está usando la variable "up" del script playerMovement
			anim.SetBool ("North", true); // Cada uno de estos "ifs" pone el valor de una variable para las cuatro direcciones
		} else {						  // en true. Si por ejemplo, North y East son true, entonces se reproducirá la animación
			anim.SetBool ("North", false); // correspondiente. Pero todas esas condiciones se manejan desde el Animator en Unity
		}
		if (Input.GetKey (playerMovement.right)) {
			anim.SetBool ("East", true);
		} else {
			anim.SetBool ("East", false);
		}
		if (Input.GetKey (playerMovement.down)) {
			anim.SetBool ("South", true);
		} else {
			anim.SetBool ("South", false);
		}
		if (Input.GetKey (playerMovement.left)) {
			anim.SetBool ("West", true);
		} else {
			anim.SetBool ("West", false);
		}
	}
}
