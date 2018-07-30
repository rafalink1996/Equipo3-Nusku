using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    string lastPlatform = "";
    GameObject platform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        platform = GameObject.Find(lastPlatform);
	}
    private void OnCollisionExit(Collision other)
    {
        lastPlatform = other.transform.name;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Respawn Zone"){
            Invoke("Spawn", 1);
        }
    }
    void Spawn (){
        this.transform.SetParent(platform.transform);
        this.transform.localPosition = new Vector3(0, 0, -0.00432f);
    }
}
