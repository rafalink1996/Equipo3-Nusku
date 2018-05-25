using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public GameObject Pivot;
    public float speed;
	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {

        OrbitAround(); 
    }

    void OrbitAround (){
        transform.RotateAround(Pivot.transform.position, Vector3.up, speed * Time.deltaTime);
    } 
	}

