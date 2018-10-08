using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayer : MonoBehaviour {

    Transform sel;
    public int frontLayer;
    public int behindLayer;
	// Use this for initialization
	void Start () {
        sel = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (sel.position.y < transform.position.y)
        {
            GetComponent<SpriteRenderer>().sortingOrder = behindLayer;
        }else{
            GetComponent<SpriteRenderer>().sortingOrder = frontLayer;
        }
	}
}
