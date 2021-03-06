﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTestDialogue : MonoBehaviour {


    public string characterName;
    public Sprite characterImage;
    public TextAsset theText;
    public int startLine;
    public int endLine;
    public TextBoxManager theTextBox;
    public bool destroyWhenActivated;
    public bool requireButtonPress;
    public bool hasOptions;
    public string option1;
    public int option1Line, option1EndLine;
    public string option2;
    public int option2Line, option2EndLine;
    bool waitForPress;
    public float typingSpeed;



    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if (waitForPress && Input.GetButtonDown("Interact") && !GameObject.FindObjectOfType<PlayerMovement2D>().pause)
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            waitForPress = false;
            theTextBox.typeSpeed = typingSpeed;
            theTextBox.characterName.text = characterName;
            theTextBox.image = characterImage;

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
            if (hasOptions == true)
            {
                theTextBox.choices = true;
                theTextBox.option1Text.text = option1;
                theTextBox.option2Text.text = option2;
                theTextBox.option1.onClick.AddListener(Option1);
                theTextBox.option2.onClick.AddListener(Option2);
                //theTextBox.option1.enabled = true;
                //theTextBox.option2.enabled = true;
                //theTextBox.option1Text.enabled = true;
                //theTextBox.option2Text.enabled = true;

            }
            else
            {
                option1 = null;
                option2 = null;
                theTextBox.option1.enabled = false;
                theTextBox.option2.enabled = false;
                theTextBox.option1Text.enabled = false;
                theTextBox.option2Text.enabled = false;
            }
        }
        //if (theTextBox.currentLine == 13 || theTextBox.currentLine == 18)
        //{
        //    option1Line = 21;
        //    option1EndLine = 22;
        //}
        //if (theTextBox.endAtLine == 22)
        //{
        //    theTextBox.choices = false;
        //}

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                return;
            }
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            theTextBox.typeSpeed = typingSpeed;
            theTextBox.characterName.text = characterName;
            theTextBox.image = characterImage;


            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
            if (hasOptions == true)
            {
                theTextBox.choices = true;
                theTextBox.option1Text.text = option1;
                theTextBox.option2Text.text = option2;
                theTextBox.option1.onClick.AddListener(Option1);
                theTextBox.option2.onClick.AddListener(Option2);

                //theTextBox.option1.enabled = true;
                //theTextBox.option2.enabled = true;
                //theTextBox.option1Text.enabled = true;
                //theTextBox.option2Text.enabled = true;

            }
            else
            {
                option1 = null;
                option2 = null;
                theTextBox.option1.enabled = false;
                theTextBox.option2.enabled = false;
                theTextBox.option1Text.enabled = false;
                theTextBox.option2Text.enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            waitForPress = false;
        }
    }
    public void Option1()
    {
        theTextBox.currentLine = option1Line;
        theTextBox.endAtLine = option1EndLine;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.option1.onClick.AddListener(Option3);
        theTextBox.option2.onClick.AddListener(Option4);
        theTextBox.choices = true;
    }
    public void Option2()
    {
        theTextBox.currentLine = option2Line;
        theTextBox.endAtLine = option2EndLine;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.option1.onClick.AddListener(Option3);
        theTextBox.option2.onClick.AddListener(Option4);
        theTextBox.choices = true;
    }
    public void Option3()
    {
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.currentLine = 21;
        theTextBox.endAtLine = 22;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.choices = false;

    }
    public void Option4()
    {
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.currentLine = 25;
        theTextBox.endAtLine = 26;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.choices = false;

    }
}
