using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour {

    int sel;
    string attack;
	// Use this for initialization
	void Start () {
        attack = GameObject.Find("Sel").GetComponent<PlayerMovement>().attack;
	}
	
	// Update is called once per frame
	void Update () {
        sel = GameObject.Find("Sel").GetComponent<PlayerMovement>().direction;
        if (sel == 1)
        {
            this.transform.rotation = Quaternion.Euler(0, 270, 0.13f);
            this.transform.localPosition = new Vector3(0.31f, 0, 0);
        }
        if (sel == 2)
        {
            this.transform.rotation = Quaternion.Euler(0, 315, 0.13f);
            this.transform.localPosition = new Vector3(-0.14f, -0.17f, 0);
        }
        if (sel == 3)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.transform.localPosition = new Vector3(0.51f, 0.05f, -0.13f);
        }
        if (sel == 4)
        {
            this.transform.rotation = Quaternion.Euler(0, 45, 0);
            this.transform.localPosition = new Vector3(0.41f, -0.14f, -0.13f);
        }
        if (sel == 5)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
            this.transform.localPosition = new Vector3(0.35f, -0f, -0.13f);
        }
        if (sel == 6)
        {
            this.transform.rotation = Quaternion.Euler(0, 135, 0);
            this.transform.localPosition = new Vector3(-0.02f, -0.13f, -0.13f);
        }
        if (sel == 7)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            this.transform.localPosition = new Vector3(-0.45f, 0.01f, -0.13f);
        }
        if (sel == 8)
        {
            this.transform.rotation = Quaternion.Euler(0, 225, 0);
            this.transform.localPosition = new Vector3(-0.39f, -0.14f, 0.13f);
        }
        if (Input.GetKeyDown(attack)){
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
            bullet.transform.SetParent(this.gameObject.transform);
        }
	}
}
