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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && sel.sortingOrder >= order.sortingOrder)
        {
            sel.sortingOrder = order.sortingOrder - 3;

        }
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = order.sortingOrder - 3;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sel.sortingOrder = selLayer;

        }
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = selLayer;
        }
    }
}
