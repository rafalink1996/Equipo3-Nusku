using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    float speed = 20.0f;

    string attack;
    //bool attackIsPressed = true;

	// Use this for initialization
	void Start () {
        attack = GameObject.Find("Sel").GetComponent<PlayerMovement>().attack;
	}
	
	// Update is called once per frame
	void Update () {
       /* if (Input.GetKey(attack)){
            this.transform.SetParent(GameObject.Find("Glove").transform);
        }*/

        if (Input.GetKeyUp(attack))
        {
            //attackIsPressed = false;
            this.transform.SetParent(null);
        }

       /* if (attackIsPressed == false)
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }*/
        if (transform.parent == null){
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            Destroy(this.gameObject, 1);
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
