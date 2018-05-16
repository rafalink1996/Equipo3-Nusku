using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    float speed = 5.0f;

    string attack;
    bool attackIsPressed = true;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyUp(attack)){
            attackIsPressed = false;
        }

       // if (attackIsPressed == false){
        this.transform.Translate(0, 0, speed * Time.deltaTime);
        //}

	}
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
