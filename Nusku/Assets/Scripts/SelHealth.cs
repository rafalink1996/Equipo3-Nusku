using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelHealth : MonoBehaviour
{

    public Slider healthSlider;
    public int health;
    bool invincible = false;
    bool dead;
    Animator anim;
    PlayerMovement2D sel;
    GameObject arm;
    SpriteRenderer body;
    SpriteRenderer armG;
    public AudioSource Audio;
    public AudioClip Hit;
    public AudioClip death;
 
    // Use this for initialization
    void Start()
    {
        healthSlider = GameObject.Find("Canvas/HUD/Health").GetComponent<Slider>();
        anim = GetComponentInChildren<Animator>();
        sel = FindObjectOfType<PlayerMovement2D>();
        arm = GameObject.Find("Sel/Graphics/Arm");
        body = GetComponentInChildren<SpriteRenderer>();
        armG = this.transform.Find("Graphics/Arm").gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        armG.color = body.color;
        if (health <= 0 && !dead)
        {
            anim.SetBool("Dead", true);
            Audio.PlayOneShot(death, 1);
            sel.canMove = false;
            arm.SetActive(false);
            body.color = Color.white;
            StopCoroutine("Flashing");
            dead = true;
        }
    }

    public void TakeDamage (int damageTaken)
    {
        if (invincible == false)
        {
            health = health - damageTaken;
            invincible = true;
            StartCoroutine("Flashing");
            Invoke("ResetInvincibility", 2.5f);
            Audio.PlayOneShot(Hit, 1);
        }
    }
    public void RecoverHealth (int healthRecovered)
    {
        health = health + healthRecovered;
    }
    IEnumerator Flashing()
    {
        for (int i = 0; i < 30; i++)
        {
            body.color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(.1f);
            body.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }
    void ResetInvincibility()
    {
        invincible = false;
        StopCoroutine("Flashing");
        body.color = Color.white;
    }
}
