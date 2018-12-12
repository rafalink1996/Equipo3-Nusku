using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour {

    ShootingRange shoot;
    bool isShot;
    bool done;
    AudioSource sound;
	// Use this for initialization
	void Start () {
        shoot = FindObjectOfType<ShootingRange>();
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shoot.shooting && !isShot)
        {
            transform.position = Vector2.MoveTowards(transform.position, shoot.target, 9 * Time.deltaTime);
        }
        if (transform.position == new Vector3(shoot.target.x, shoot.target.y, 0) && !done)
        {
            isShot = true;
            done = true;
            sound.Play();
        }
	}
}
