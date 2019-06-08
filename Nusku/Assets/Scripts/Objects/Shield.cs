using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour {

    PlayerMovement2D sel;
    SpriteRenderer icon;
    bool interact;
    AudioSource sound;
	// Use this for initialization
	void Start () {
        sel = FindObjectOfType<PlayerMovement2D>();
        icon = GameObject.Find("Sel/Interact_Icon").GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (interact && Input.GetButtonDown("Interact"))
        {
            sel.canMove = false;
            GameObject gotShield = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/GotShield") as GameObject);
            gotShield.name = "GotShield";
            GameObject canvas = GameObject.Find("Canvas");
            gotShield.transform.SetParent(canvas.transform, false);
            gotShield.GetComponentInChildren<Button>().Select();
            gotShield.GetComponentInChildren<Button>().OnSelect(null);
            sound.enabled = true;
            //gotShield.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            //gotShield.GetComponent<RectTransform>().localPosition = Vector2.zero;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interact = true;
            icon.enabled = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interact = false;
            icon.enabled = false;

        }
    }
}
