using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur : MonoBehaviour {

    int health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		print("health = " + health); 
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet"){
            health = health - 10;
        }
    }
    public void Attack(){
        GameObject.Find("Mouth").GetComponent<JurMouth>().JurAttack();
    }
}
