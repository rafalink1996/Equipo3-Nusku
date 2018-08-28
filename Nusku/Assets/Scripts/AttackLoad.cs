using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLoad : MonoBehaviour {

    PlayerMovement2D sel;
	
	void Start () {
        sel = FindObjectOfType<PlayerMovement2D>();
	}
	
	
	void Update () {
        if (sel.canMove == false)
        {
            Destroy(this.gameObject);
        }
        this.transform.position = this.transform.parent.position;
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            this.GetComponent<ParticleSystemRenderer>().sortingOrder = 3;
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            this.GetComponent<ParticleSystemRenderer>().sortingOrder = 6;
        }
	}
}
