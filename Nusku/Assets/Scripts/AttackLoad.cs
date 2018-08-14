using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLoad : MonoBehaviour {

  
	
	void Start () {

	}
	
	
	void Update () {
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
