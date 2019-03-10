using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedriDialogue : MonoBehaviour {

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
    public SpriteRenderer icon;
    bool talking;
    Animator anim;
    bool end;



    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        icon = GameObject.Find("Sel/Interact_Icon").GetComponent<SpriteRenderer>();
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameStats.stats.hasFishingRod == false)
        {
            startLine = 1;
            endLine = 8;
        }
        if (GameStats.stats.hasFishingRod == true)
        {
            startLine = 11;
            endLine = 17;
        }


        if (waitForPress && Input.GetButtonDown("Interact"))
        {
            end = false;
            anim.ResetTrigger("TurnBack");
            theTextBox.option1.onClick.RemoveAllListeners();
            theTextBox.option2.onClick.RemoveAllListeners();
            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
            waitForPress = false;
            theTextBox.typeSpeed = typingSpeed;
            theTextBox.characterName.text = characterName;
            theTextBox.image = characterImage;
            icon.enabled = false;
            anim.SetTrigger("Turn");

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
        if (theTextBox.currentLine == theTextBox.endAtLine && theTextBox.isTyping == false && !theTextBox.choices)
        {
            end = true;
        }
        if (Input.GetButtonDown("Interact") && end)
        {
            anim.SetTrigger("TurnBack");
            end = false;
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
            theTextBox.option1.onClick.RemoveAllListeners();
            theTextBox.option2.onClick.RemoveAllListeners();
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
            talking = false;
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