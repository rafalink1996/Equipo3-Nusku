using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{

    public GameObject instructions;
    Animator anim;
    SpriteRenderer icon;
    bool press;
    bool active;
    public bool first;
    PlayerMovement2D sel;

    // Start is called before the first frame update
    void Start()
    {
        anim = instructions.GetComponent<Animator>();
        icon = GameObject.Find("Sel/Interact_Icon").GetComponent<SpriteRenderer>();
        sel = FindObjectOfType<PlayerMovement2D>();
        if (first && !GameStats.stats.firstInstructions){
            instructions.SetActive(true);
            Invoke("Active", 0.5f);
            sel.canMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && press && !active && !GameObject.FindObjectOfType<PlayerMovement2D>().pause)
        {
            instructions.SetActive(true);
            Invoke("Active", 0.5f);
            sel.canMove = false;
        }
        if (Input.GetButtonDown("Interact") && active || Input.GetButtonDown("Pause") && active)
        {
            anim.SetTrigger("Fade");
            Invoke("Disable", 0.5f);
            GameStats.stats.firstInstructions = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        icon.enabled = true;
        press = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        icon.enabled = false;
        press = false;
    }
    void Active(){
        active = true;
    }
    void Disable(){
        instructions.SetActive(false);
        sel.canMove = true;
        active = false;
    }
}
