using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelHealth : MonoBehaviour {

    public Slider healthSlider;
	// Use this for initialization
	void Start () {
        healthSlider = GameObject.Find("Canvas/HUD/Health").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            healthSlider.value = healthSlider.value - 10;

        }
    }
}
