using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Stalactite")
        {
            collision.collider.GetComponent<Animator>().SetTrigger("Destroy");
            collision.transform.Find("StalactiteTop").gameObject.SetActive(false);
            //collision.collider.transform.chil;
        }
    }
    void NotFalling()
    {
        this.gameObject.tag = "Stalactite";
    }
    void Destroyed ()
    {
        Destroy(this.gameObject);
    }
}

