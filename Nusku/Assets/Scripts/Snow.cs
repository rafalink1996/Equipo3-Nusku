using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour {

    public AudioSource tree;
	// Use this for initialization
	void Start () {
        if (GameStats.stats.hasGlove)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Bullet")
        {
            tree.enabled = true;
            Destroy(gameObject);
        }
    }
}
