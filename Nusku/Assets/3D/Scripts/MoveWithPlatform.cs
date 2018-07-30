using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // this.transform.rotation = Quaternion.Euler(0, 0, 0, Space.World);

	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player"){
            collision.collider.transform.SetParent(transform);
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }

    }
}
