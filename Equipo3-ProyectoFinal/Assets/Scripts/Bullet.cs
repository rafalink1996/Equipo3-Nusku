using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    float speed = 10.0f;

    string attack;
    bool attackIsPressed = true;

	// Use this for initialization
	void Start () {
        attack = GameObject.Find("Sel").GetComponent<PlayerMovement>().attack;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(attack)){
            this.transform.SetParent(GameObject.Find("Glove").transform);
        }
        
        if (Input.GetKeyUp(attack)){
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            this.transform.SetParent(null);
        }
        //   attackIsPressed = false;
        //}

        // if (attackIsPressed == false){
	}
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
