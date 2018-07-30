using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{

    public AudioSource myAudio;

    // Use this for initialization
    void Start()
    {

        myAudio = GetComponent<AudioSource>();
        myAudio.PlayDelayed(29.510f);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
