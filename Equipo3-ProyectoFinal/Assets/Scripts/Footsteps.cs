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


    void Update()
    {
        if (Input.GetKey(up) || Input.GetKey(down) ||  Input.GetKey(left) ||  Input.GetKey(right)) 
        {
            audioS.volume = Random.Range(0.5f, 1);
            audioS.enabled = true;
        } else {
            audioS.enabled = false;

        }
    }

}