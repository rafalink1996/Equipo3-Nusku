using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour {

    int sel;
    string attack;
    bool dead;
    //bool attackReady;
	// Use this for initialization
	void Start () {
        attack = GameObject.Find("Sel").GetComponent<PlayerMovement>().attack;
	}

    // Update is called once per frame
    void Update()
    {
        sel = GameObject.Find("Sel").GetComponent<PlayerMovement>().direction;
        dead = GameObject.Find("Sel").GetComponent<PlayerMovement>().dead;
        if (sel == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 270, 0.13f);
            this.transform.localPosition = new Vector3(-0.21f, 0, 0.24f);
        }
        if (sel == 2)
        {
            this.transform.rotation = Quaternion.Euler(0, 315, 0.13f);
            this.transform.localPosition = new Vector3(0.34f, 0f, 0.24f);
        }
        if (sel == 3)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.transform.localPosition = new Vector3(0.53f, 0.05f, -0.13f);
        }
        if (sel == 4)
        {
            this.transform.rotation = Quaternion.Euler(0, 45, 0);
            this.transform.localPosition = new Vector3(0.68f, -0.14f, -0.13f);
        }
        if (sel == 5)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
            this.transform.localPosition = new Vector3(0.35f, -0f, -0.13f);
        }
        if (sel == 6)
        {
            this.transform.rotation = Quaternion.Euler(0, 135, 0);
            this.transform.localPosition = new Vector3(-0.42f, -0.13f, -0.13f);
        }
        if (sel == 7)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            this.transform.localPosition = new Vector3(-0.48f, 0.05f, -0.13f);
        }
        if (sel == 8)
        {
            this.transform.rotation = Quaternion.Euler(0, 225, 0);
            this.transform.localPosition = new Vector3(-0.64f, 0f, 0.13f);
        }
        //attackReady = GameObject.Find("Sel").GetComponent<PlayerMovement>().attackReady;
        //if (attackReady == true){
        if (Input.GetKeyDown(attack) && dead == false)
        {
            //Invoke("FireBullet", 0.7f);
            /*}
        }
        void FireBullet (){*/
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
            bullet.transform.SetParent(this.gameObject.transform);
            bullet.transform.localPosition = new Vector3(0, 0, 0);
            bullet.transform.rotation = this.gameObject.transform.rotation;
        }
    }
}
