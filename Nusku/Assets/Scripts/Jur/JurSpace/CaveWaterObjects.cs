using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveWaterObjects : MonoBehaviour {

    Animator anim;
    Jur2D jur;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        jur = FindObjectOfType<Jur2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (jur.froze)
        {
            anim.SetBool("Froze", true);
        }
	}
}
