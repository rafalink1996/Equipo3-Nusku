using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Sprite one;
    public Sprite two;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<PlayerMovement2D>().canMove == true)
        {
            GetComponent<SpriteRenderer>().sprite = one;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = two;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement2D>().canMove == true)
        {
            GetComponent<SpriteRenderer>().sprite = one;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = two;
        }
    }
}
