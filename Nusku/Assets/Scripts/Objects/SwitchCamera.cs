using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour {

    public GameObject cam;
    public GameObject cam2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam.SetActive(true);
            cam2.SetActive(false);
            //}else{
            //    cam.SetActive(false);
            //    cam2.SetActive(true);
            //}
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cam.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
