using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

    Animator anim;
    public Animator column;
    public Animator column2;
    public GameObject jur;
    FollowPlayer cam;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        cam = FindObjectOfType<FollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Break");
            column.SetTrigger("Fade");
            column2.SetTrigger("Fade");
            jur.SetActive(true);
            cam.player = null;
        }
    }
}
