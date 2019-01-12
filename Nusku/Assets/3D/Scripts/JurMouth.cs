using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurMouth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void JurAttack(){
        GameObject jurAttack = GameObject.Instantiate(Resources.Load("Prefabs/JurBullet") as GameObject);
        jurAttack.name = "JurBullet";
        jurAttack.transform.localPosition = new Vector3(0, 0, 0);
        jurAttack.transform.localRotation = this.transform.rotation;
    }
}
