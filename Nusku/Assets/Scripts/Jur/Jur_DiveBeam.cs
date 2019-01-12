using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur_DiveBeam : MonoBehaviour {

    public int damage;
    SelHealth sel;
	// Use this for initialization
	void Start () {
        sel = FindObjectOfType<SelHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            sel.TakeDamage(damage);
        }
    }
    void Over()
    {
        Destroy(gameObject);
    }
}
