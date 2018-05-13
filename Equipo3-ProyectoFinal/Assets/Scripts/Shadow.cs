using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

	public Transform character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		transform.position = new Vector3 (character.transform.position.x, -1f, character.transform.position.z);;
	}
}
