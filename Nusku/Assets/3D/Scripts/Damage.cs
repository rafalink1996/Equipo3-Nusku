using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public AudioSource damage;
    public AudioSource splashdamage;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            damage.Play();
            splashdamage.Play();
        }

        if (collision.collider.gameObject.tag == "Respawn")
        {
            damage.Play();
        }
    }
}