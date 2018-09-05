using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelHealth : MonoBehaviour {

    public Slider healthSlider;
    bool invincible = false;
    Animator anim;
    PlayerMovement2D sel;
    GameObject arm;
	// Use this for initialization
	void Start () {
        healthSlider = GameObject.Find("Canvas/HUD/Health").GetComponent<Slider>();
        anim = GetComponentInChildren<Animator>();
        sel = FindObjectOfType<PlayerMovement2D>();
        arm = GameObject.Find("Sel/Graphics/Arm");
	}
	
	// Update is called once per frame
	void Update () {
        if (healthSlider.value <= 0)
        {
            anim.SetBool("Dead", true);
            sel.canMove = false;
            arm.SetActive(false);
        }
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
                healthSlider.value = healthSlider.value - 10;
                invincible = true;
                Invoke("ResetInvincibility", 2.5f);
            }
            if (collision.collider.gameObject.name == "Jur_Bullet")
            {
                healthSlider.value = healthSlider.value - 30;
                invincible = true;
                Invoke("ResetInvincibility", 2.5f);
            }
            if (collision.collider.gameObject.name == "JurHomingBullet")
            {
                healthSlider.value = healthSlider.value - 15;
                invincible = true;
                Invoke("ResetInvincibility", 2.5f);
            }
        }
    }
    void ResetInvincibility(){
        invincible = false;
    }
}
