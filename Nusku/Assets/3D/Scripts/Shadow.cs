using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

	public Transform character;
    bool sel;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void LateUpdate()
    {
        sel = GameObject.Find("Sel").GetComponent<PlayerMovement>().isGrounded;
        if (sel == true)
        {

            transform.position = new Vector3(character.transform.position.x, character.transform.position.y - 2.1f, character.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(character.transform.position.x, -0.38f, character.transform.position.z);
        }
    }
}
