using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public bool move;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Sel").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            transform.position = player.position + offset;
            move = false;
        }
        else
        {
            move = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-0.62f, 0.97f, -10), 0.1f);
           
        }
        if (move == true)
        {
            GetComponent<Camera>().orthographicSize += 0.03f;
        }
        if (GetComponent<Camera>().orthographicSize >= 4)
        {
            GetComponent<Camera>().orthographicSize = 4;
            move = false;
        }
    }
}
