using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour
{

    public SpriteRenderer icon;
    public Vector2 destination;
    public int selDirectionX;
    public int selDirectionY;
    GameObject sel;
    bool canInteract;
    public GameObject activateCamera;
    public GameObject deactivateCamera;
    Animator black;

    // Use this for initialization
    void Start()
    {
        sel = GameObject.FindWithTag("Player");
        black = GameObject.Find("Canvas/Black").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetButtonDown("Interact"))
        {
            black.SetTrigger("Fade");
            Invoke("Switch", 0.5f);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            icon.enabled = true;
            canInteract = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            icon.enabled = false;
            canInteract = false;
        }
    }
    void Switch()
    {
            sel.transform.position = destination;
            sel.GetComponentInChildren<Animator>().SetFloat("LastX", selDirectionX);
            sel.GetComponentInChildren<Animator>().SetFloat("LastY", selDirectionY);
            activateCamera.SetActive(true);
            deactivateCamera.SetActive(false);
    }
}
