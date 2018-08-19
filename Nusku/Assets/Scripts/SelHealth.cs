using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelHealth : MonoBehaviour {

    public Slider healthSlider;
    bool invincible = false;
	// Use this for initialization
	void Start () {
        healthSlider = GameObject.Find("Canvas/HUD/Health").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invincible == false)
        {
            if (collision.collider.gameObject.tag == "Enemy")
            {
                healthSlider.value = healthSlider.value - 10;
                invincible = true;
                Invoke("ResetInvincibility", 2.5f);
            }
            if (collision.collider.gameObject.tag == "Hazard")
            {
                healthSlider.value = healthSlider.value - 5;
                invincible = true;
                Invoke("ResetInvincibility", 2.5f);
            }
        }
    }
    void ResetInvincibility(){
        invincible = false;
    }
}
