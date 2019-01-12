using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoxDialogue : MonoBehaviour {

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
    public SpriteRenderer icon;



    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        icon = GameObject.Find("Sel/Interact_Icon").GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.stats.hasPlayedDarts == false && GameStats.stats.hasWonDarts == false){
            startLine = 0;
            endLine = 1;
        }
        if (GameStats.stats.hasPlayedDarts == true && GameStats.stats.hasWonDarts == false)
        {
            startLine = 4;
            endLine = 4;
        }
        if (GameStats.stats.hasPlayedDarts == true && GameStats.stats.hasWonDarts == true)
        {
            startLine = 7;
            endLine = 9;
        }

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
            icon.enabled = false;

            if (destroyWhenActivated)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<EdgeCollider2D>().enabled = false;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (requireButtonPress)
            {
                waitForPress = true;
                icon.enabled = true;
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
                GetComponent<EdgeCollider2D>().enabled = false;
            }
            if (hasOptions == true)
            {
                theTextBox.choices = true;
                theTextBox.option1Text.text = option1;
                theTextBox.option2Text.text = option2;
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
            icon.enabled = false;
        }
    }
    public void Option1() //Well, I was in the train...
    {

        theTextBox.currentLine = option1Line;
        theTextBox.endAtLine = option1EndLine;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.choices = false;

    }
    public void Option2() //Who are you?
    {
        theTextBox.currentLine = option2Line;
        theTextBox.endAtLine = option2EndLine;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.choices = false;

    }
}
