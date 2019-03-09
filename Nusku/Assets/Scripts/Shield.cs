using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour {

    PlayerMovement2D sel;
	// Use this for initialization
	void Start () {
        sel = FindObjectOfType<PlayerMovement2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sel.canMove = false;
            GameObject gotShield = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/GotShield") as GameObject);
            gotShield.name = "GotShield";
            GameObject canvas = GameObject.Find("Canvas");
            gotShield.transform.SetParent(canvas.transform, false);
            gotShield.GetComponentInChildren<Button>().Select();
            gotShield.GetComponentInChildren<Button>().OnSelect(null);
            //gotShield.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            //gotShield.GetComponent<RectTransform>().localPosition = Vector2.zero;
        }
    }
}
