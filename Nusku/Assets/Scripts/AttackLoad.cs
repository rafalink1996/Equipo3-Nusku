using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            this.GetComponent<ParticleSystemRenderer>().sortingOrder = 0;
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            this.GetComponent<ParticleSystemRenderer>().sortingOrder = 3;
        }
	}
}
