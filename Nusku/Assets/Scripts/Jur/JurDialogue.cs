using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JurDialogue : MonoBehaviour {


    public string characterName;
    public Sprite characterImage;
    public Sprite selImage;
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
    public bool lastOne;



    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        if (hasOptions)
        {
            lastOne = false;
        }else{
            lastOne = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (waitForPress && Input.GetButtonDown("Interact"))
        {
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            waitForPress = false;
            theTextBox.typeSpeed = typingSpeed;
            theTextBox.characterName.text = characterName;
            theTextBox.image = characterImage;

            //if (destroyWhenActivated)
            //{
            //        Destroy(gameObject);
            //}
            if (hasOptions == true)
            {
                theTextBox.choices = true;
                theTextBox.option1Text.text = option1;
                theTextBox.option2Text.text = option2;
                theTextBox.option1.onClick.AddListener(Option1);
                theTextBox.option2.onClick.AddListener(Option2);
            
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
        //Cuando tiene que ir de una línea a otra
        if (theTextBox.currentLine == 8){
            theTextBox.currentLine = 16;
            theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        }
        if (theTextBox.currentLine == 27)
        {
            theTextBox.currentLine = 49;
            theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        }
        if (theTextBox.currentLine == 56)
        {
            theTextBox.currentLine = 49;
            theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        }
        if (theTextBox.currentLine == 46)
        {
            theTextBox.currentLine = 49;
            theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        }
        //Nombre e imagen de Sel
        if (theTextBox.currentLine == 14 || theTextBox.currentLine == 24 || theTextBox.currentLine == 26 || theTextBox.currentLine == 39 || theTextBox.currentLine == 63 || theTextBox.currentLine == 67){
            theTextBox.image = selImage;
            theTextBox.characterName.text = "Sel";
        }else{
            theTextBox.characterName.text = characterName;
            theTextBox.image = characterImage;
        }

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
                GetComponent<BoxCollider2D>().enabled = false;
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
    public void Option1() //Sel
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
        theTextBox.option1Text.text = "Not really";
        theTextBox.option2Text.text = "Yes";
    }
    public void Option2() //Aren't you an oracle?
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
        theTextBox.option1Text.text = "Not really";
        theTextBox.option2Text.text = "Yes";
    }
    public void Option3() //Not really
    {
        theTextBox.currentLine = 22;
        theTextBox.endAtLine = 50;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.option1.onClick.AddListener(Option7);
        theTextBox.option2.onClick.AddListener(Option8);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "You are";
        theTextBox.option2Text.text = "You are not";

    }
    public void Option4() //Yes
    {
        theTextBox.currentLine = 32;
        theTextBox.endAtLine = 32;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.option1.onClick.AddListener(Option5);
        theTextBox.option2.onClick.AddListener(Option6);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "About the tide";
        theTextBox.option2Text.text = "About you";

    }
    public void Option5() //About the tide
    {
        theTextBox.currentLine = 38;
        theTextBox.endAtLine = 50;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.option1.onClick.AddListener(Option7);
        theTextBox.option2.onClick.AddListener(Option8);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "You are";
        theTextBox.option2Text.text = "You are not";
    }
    public void Option6() //About you
    {
        theTextBox.currentLine = 45;
        theTextBox.endAtLine = 50;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.option1.onClick.AddListener(Option7);
        theTextBox.option2.onClick.AddListener(Option8);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "You are";
        theTextBox.option2Text.text = "You are not";
    }
    public void Option7() //You are
    {
        theTextBox.currentLine = 60;
        theTextBox.endAtLine = 69;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.choices = false;
        theTextBox.option1Text.text = "ERROR";
        theTextBox.option2Text.text = "ERROR";
        lastOne = true;
    }
    public void Option8() //You are not
    {
        theTextBox.currentLine = 66;
        theTextBox.endAtLine = 69;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.option1.enabled = false;
        theTextBox.option2.enabled = false;
        theTextBox.option1Text.enabled = false;
        theTextBox.option2Text.enabled = false;
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.choices = false;
        theTextBox.option1Text.text = "ERROR";
        theTextBox.option2Text.text = "ERROR";
        lastOne = true;
    }
}
