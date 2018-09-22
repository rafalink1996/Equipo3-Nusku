using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public int damage;
    SelHealth sel;
    // Use this for initialization
    void Start()
    {
        sel = FindObjectOfType<SelHealth>();
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
        if (collision.collider.tag == "Player" && this.gameObject.tag == "Hazard")
        {
            sel.TakeDamage(damage);
        }
    }
    void NotFalling()
    {
        this.gameObject.tag = "Stalactite";
    }
    void Destroyed()
    {
        Destroy(this.gameObject);
    }
}

