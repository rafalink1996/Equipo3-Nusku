using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeBrdige : MonoBehaviour {

    EdgeCollider2D coll;
	// Use this for initialization
	void Start () {
        coll = GetComponent<EdgeCollider2D>();
        if (GameStats.stats.fishes >= 3)
        {
            coll.enabled = false;
        }else{
            coll.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
