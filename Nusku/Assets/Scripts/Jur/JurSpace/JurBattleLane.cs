using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurBattleLane : MonoBehaviour {

    public float direction;
    Jur2D jur;
	// Use this for initialization
	void Start () {
        jur = FindObjectOfType<Jur2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            jur.direction = direction;
        }
    }
}
