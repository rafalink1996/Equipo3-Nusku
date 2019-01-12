using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour {

    public SpriteRenderer icon;
    bool press;
    SelHealth selHealth;
	// Use this for initialization
	void Start () {
        icon = GameObject.Find("Sel/Interact_Icon").GetComponent<SpriteRenderer>();
        selHealth = FindObjectOfType<SelHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Interact") && press){
            selHealth.health = 100;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        icon.enabled = true;
        press = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        icon.enabled = false;
        press = false;
    }
}
