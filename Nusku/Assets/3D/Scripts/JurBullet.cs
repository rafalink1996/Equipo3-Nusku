using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JurBullet : MonoBehaviour {

    public AudioSource hit;

    // Use this for initialization
    void Start () {
        Destroy(this.gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(20f * Time.deltaTime, 0, 0);
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            hit.Play();
        }
        if (collision.collider.gameObject.tag == "Ground"){
            print("bullet hit platform"); 
        }
    }


}
