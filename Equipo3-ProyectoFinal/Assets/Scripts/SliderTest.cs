using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour {

    public Slider sliderHealth;
    Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sliderHealth = GameObject.Find("Canvas/HUD/Health").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {

        //sliderHealth.value = GetComponent<PlayerMovement>().health;
        if (sliderHealth.value <= 0){
            anim.SetBool("Dead", true);
            GetComponent<PlayerMovement>().enabled = false;
            GameObject.Find("Glove").GetComponent<Glove>().enabled = false;
            GameObject.Find("Footsteps").active = false;
            GameObject.Find("Damage").active = false;


        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            sliderHealth.value = sliderHealth.value - 10;

        }
        if (collision.collider.gameObject.name == "Respawn Zone"){
            sliderHealth.value = sliderHealth.value - 5;
        }
    }

}
