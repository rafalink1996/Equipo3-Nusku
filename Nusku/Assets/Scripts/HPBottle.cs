using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBottle : MonoBehaviour {

    SelHealth sel;
    public int hpRecovered;
	// Use this for initialization
	void Start () {
        sel = FindObjectOfType<SelHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            sel.RecoverHealth(hpRecovered);
            Destroy(gameObject);
        }
    }
   
}
