using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour {

    ShootingRange shoot;
    bool isShot;
	// Use this for initialization
	void Start () {
        shoot = FindObjectOfType<ShootingRange>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shoot.shooting && !isShot)
        {
            transform.position = Vector2.MoveTowards(transform.position, shoot.target, 9 * Time.deltaTime);
        }
        if (transform.position == new Vector3(shoot.target.x, shoot.target.y, 0))
        {
            isShot = true;
        }
	}
}
