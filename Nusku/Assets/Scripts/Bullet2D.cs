using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet2D : MonoBehaviour {

    float speed = 10.0f;


    void Start()
    {

    }

    void Update()
    {

        if (transform.parent == null)
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            Destroy(this.gameObject, 1);
        }
        if (this.transform.parent != null){
            if (Input.GetAxisRaw("Vertical") == 1){
                this.GetComponent<ParticleSystemRenderer>().sortingOrder = 0;
            }
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                this.GetComponent<ParticleSystemRenderer>().sortingOrder = 3;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != "Player" && this.transform.parent == null)
        {
            Destroy(this.gameObject);
        }
    }
}
