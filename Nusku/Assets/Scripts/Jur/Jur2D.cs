using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur2D : MonoBehaviour {


    Animator anim;
    public float direction;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
   
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    void Shoot (){
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Jur_Bullet") as GameObject);
        bullet.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        bullet.name = "Jur_Bullet";
      
    }
}
