using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontRotateWhenDead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.parent == null)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(-this.transform.parent.rotation.x, -this.transform.parent.rotation.y, -this.transform.parent.rotation.z);
        }
	}
}
