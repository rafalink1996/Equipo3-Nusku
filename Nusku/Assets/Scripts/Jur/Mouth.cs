using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public int damage = 10;
    SelHealth sel;
    // Start is called before the first frame update
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
        if (collision.collider.tag == "Player")
        {
            sel.TakeDamage(damage);

        }
    }
}
