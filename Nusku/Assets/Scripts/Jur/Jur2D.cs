using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur2D : MonoBehaviour {


    Animator anim;
    public float direction;
    public float health;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
   
	}
	
	// Update is called once per frame
	void Update () {
       if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            health = health - 10f;
            print("hit");
        }
    }
    void Shoot (){
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Jur_Bullet") as GameObject);
        bullet.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        bullet.name = "Jur_Bullet";
    }
    void HomingBullet()
    {
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/JurHomingBullet") as GameObject);
        bullet.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        bullet.name = "JurHomingBullet";
    }
}
