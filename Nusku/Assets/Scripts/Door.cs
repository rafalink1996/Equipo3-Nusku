using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public SpriteRenderer icon;
    public Vector2 destination;
    public int selDirectionX;
    public int selDirectionY;
    GameObject sel;
    bool canInteract;

	// Use this for initialization
	void Start () {
        sel = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (canInteract && Input.GetButtonDown("Interact"))
        {
            sel.transform.position = destination;
            sel.GetComponentInChildren<Animator>().SetFloat("LastX", selDirectionX);
            sel.GetComponentInChildren<Animator>().SetFloat("LastY", selDirectionY);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            icon.enabled = true;
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            icon.enabled = false;
            canInteract = false;
        }
    }
}
