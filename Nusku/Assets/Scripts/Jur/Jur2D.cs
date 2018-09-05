using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur2D : MonoBehaviour {


    Animator anim;
    public float direction;
    public float health;
    public GameObject freeze;
    public GameObject water;
    TextBoxManager textBox;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        textBox = FindObjectOfType<TextBoxManager>();
   
	}
	
	// Update is called once per frame
	void Update () {
       if (health <= 0)
        {
            this.gameObject.SetActive(false);
            freeze.SetActive(true);
            water.SetActive(false);
        }
        if (textBox.currentLine > textBox.endAtLine)
        {
            anim.SetTrigger("BattleStart");
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
    void IceJavelin()
    {
        GameObject javelin1 = GameObject.Instantiate(Resources.Load("Prefabs/IceJavelin") as GameObject);
        javelin1.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        javelin1.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-75f, -60f));
        javelin1.name = "IceJavelin";
        GameObject javelin2 = GameObject.Instantiate(Resources.Load("Prefabs/IceJavelin") as GameObject);
        javelin2.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        javelin2.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-45f, -30f));
        javelin2.name = "IceJavelin";
        GameObject javelin3 = GameObject.Instantiate(Resources.Load("Prefabs/IceJavelin") as GameObject);
        javelin3.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        javelin3.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-5f, 10f));
        javelin3.name = "IceJavelin";
    }
}
