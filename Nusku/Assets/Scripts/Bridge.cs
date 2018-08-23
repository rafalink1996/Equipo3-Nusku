using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    Animator anim;
    public Animator column;
    public Animator column2;
    // Use this for initialization
    void Start()
    {
        anim = GetComponentInParent<Animator>();
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
        }
    }
}
