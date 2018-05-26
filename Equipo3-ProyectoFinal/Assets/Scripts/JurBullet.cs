using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurBullet : MonoBehaviour {

    public AudioSource hit;

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(20f * Time.deltaTime, 0, 0);
	}

   
}
