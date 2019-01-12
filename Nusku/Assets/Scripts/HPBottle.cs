using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBottle : MonoBehaviour {

    SelHealth sel;
    public int hpRecovered;
    public AudioSource audiosource;
    public AudioClip drink;
	// Use this for initialization
	void Start () {
        sel = FindObjectOfType<SelHealth>();
        audiosource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            sel.RecoverHealth(hpRecovered);
            audiosource.PlayOneShot(drink, 3);
            Destroy(gameObject);

        }
    }
   
}
