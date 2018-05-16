using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    float speed = 3.0f;
    int sel;
    string attack;
    bool attackIsPressed;

	// Use this for initialization
	void Start () {
        attack = GameObject.Find("Sel").GetComponent<PlayerMovement>().attack;
	}
	
	// Update is called once per frame
	void Update () {
        sel = GameObject.Find("Sel").GetComponent<PlayerMovement>().direction;
        if (sel == 1){
            this.transform.rotation = Quaternion.Euler(0,-90, 0);
        }
        if (Input.GetKey(attack)){
            attackIsPressed = true;
        }else{
            attackIsPressed = false;
        }
        if (attackIsPressed == false){
           // this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }

	}
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
