using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pato : MonoBehaviour {
	public static int score;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			this.gameObject.transform.Translate (1, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			this.gameObject.transform.Translate (-1, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			this.gameObject.transform.Translate (0, 1, 0);

		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			this.gameObject.transform.Translate (0, -1, 0);
		}

	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.collider.gameObject.tag == "cuad1") {
			ScoreManager.score += 500;
			print ("puntos +500");
		}

		if (col.collider.gameObject.tag == "cuad2") {
			ScoreManager.score += 1000;
			}

		if (col.collider.gameObject.tag == "cuad3") {
			ScoreManager.score += 1500;
		}
	}




	}


	

