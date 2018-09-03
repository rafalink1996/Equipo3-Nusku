using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur_HomingBullet : MonoBehaviour {

    public float speed;
    Transform target;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Stalactite")
        {
            Destroy(this.gameObject);
        }
    }
}
