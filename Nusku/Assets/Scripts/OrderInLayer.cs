using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderInLayer : MonoBehaviour {

    public SpriteRenderer sel;
    SpriteRenderer order;
    int selLayer = 5;
	// Use this for initialization
	void Start () {
        order = GetComponent<SpriteRenderer>();
        sel = GameObject.Find("Sel/Graphics").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sel.sortingOrder = order.sortingOrder - 3;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sel.sortingOrder = selLayer;

        }
    }
}
