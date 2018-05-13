using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    bool playerismoving;
    public AudioSource audioS;
    public string up;
    public string down;
    public string right;
    public string left;
    bool isGrounded = true;




    void Update()
    {
        if (Input.GetKey(up) && isGrounded == true || Input.GetKey(down) && isGrounded == true ||  Input.GetKey(left) && isGrounded == true ||  Input.GetKey(right) && isGrounded == true)
        {
            audioS.volume = Random.Range(0.5f, 1);
            audioS.enabled = true;
        } else {
            audioS.enabled = false;

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}

