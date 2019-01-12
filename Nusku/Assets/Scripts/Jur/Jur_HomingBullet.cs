using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur_HomingBullet : MonoBehaviour {

    public float speed;
    Transform target;
    public int damage;
    SelHealth sel;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sel = FindObjectOfType<SelHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Stalactite" && collision.collider.name != "Bullet")
        {
            Destroy(this.gameObject);
        }
        if (collision.collider.tag == "Player")
        {
            sel.TakeDamage(damage);
        }
    }
}
