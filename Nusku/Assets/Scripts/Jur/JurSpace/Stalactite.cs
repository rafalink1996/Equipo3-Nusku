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
            Destroy(collision.gameObject);
        }
    }
    void NotFalling()
    {
        this.gameObject.tag = "Stalactite";
    }
}

