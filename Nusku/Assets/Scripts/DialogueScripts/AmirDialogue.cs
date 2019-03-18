using System.Collections;
using System.Collections.Generic;
    using UnityEngine;

public class AmirDialogue : MonoBehaviour {

    public string characterName;
    public Sprite characterImage;
    public Sprite selImage;
    public Sprite gloves;
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
    public Sprite[] expression;
    Glove2D glove;
    public SpriteRenderer icon;
    bool end;
    public GameObject mainMusic;
    public GameObject amirMusic;



    // Use this for initialization
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
        glove = FindObjectOfType<Glove2D>();
        if (hasOptions)
        {
            lastOne = false;
        }
        else
        {
            lastOne = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.stats.hasGlove == true)
        {
            startLine = 49;
            endLine = 51;
            hasOptions = false;
        }

        if (waitForPress && Input.GetButtonDown("Interact"))
        {
            mainMusic.SetActive(false);
            amirMusic.SetActive(true);
            end = false;
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
        if (theTextBox.currentLine == 43)
        {
            theTextBox.currentLine = 16;
            theTextBox.endAtLine = 25;
            theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        }
        if (theTextBox.currentLine == 46)
        {
            theTextBox.currentLine = 16;
            theTextBox.endAtLine = 25;
            theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        }
        //if (theTextBox.currentLine == )

        //Nombre e imagen de Sel
        if (theTextBox.currentLine == 29 || theTextBox.currentLine == 10 || theTextBox.currentLine == 16 || theTextBox.currentLine == 19)
        {
            theTextBox.image = selImage;
            theTextBox.characterName.text = "Sel";

        }
        else
        {
            theTextBox.characterName.text = characterName;

            //Expresiones de Amir
            if (theTextBox.currentLine == 0 || theTextBox.currentLine == 3 || theTextBox.currentLine == 12 || theTextBox.currentLine == 18 || theTextBox.currentLine == 28 || theTextBox.currentLine == 32 || theTextBox.currentLine == 40 || theTextBox.currentLine == 22)
            {
                theTextBox.image = expression[0];
            }
            if (theTextBox.currentLine == 4 || theTextBox.currentLine == 14 || theTextBox.currentLine == 20 || theTextBox.currentLine == 23 || theTextBox.currentLine == 37)
            {
                theTextBox.image = expression[2];
            }
            if (theTextBox.currentLine == 6 || theTextBox.currentLine == 9 || theTextBox.currentLine == 15 || theTextBox.currentLine == 24 || theTextBox.currentLine == 31 || theTextBox.currentLine == 36 || theTextBox.currentLine == 39)
            {
                theTextBox.image = expression[3];
            }
            if (theTextBox.currentLine == 8 || theTextBox.currentLine == 26 || theTextBox.currentLine == 42)
            {
                theTextBox.image = expression[4];
            }
            if (theTextBox.currentLine == 11 || theTextBox.currentLine == 21 || theTextBox.currentLine == 35 || theTextBox.currentLine == 45)
            {
                theTextBox.image = expression[5];
            }
            if (theTextBox.currentLine == 2 || theTextBox.currentLine == 17 || theTextBox.currentLine == 27)
            {
                theTextBox.image = expression[6];
            }
            if (theTextBox.currentLine == 15 || theTextBox.currentLine == 24)
            {
                theTextBox.image = gloves;
                theTextBox.characterName.text = "";
            }
        }
        //Final activa el guante
        if (theTextBox.currentLine == 15 || theTextBox.currentLine == 24)
        {
            glove.hasGlove = true;
            GameStats.stats.hasGlove = true;
            GetComponent<AudioSource>().enabled = true;
        }
        if (theTextBox.currentLine == theTextBox.endAtLine && theTextBox.isTyping == false && !theTextBox.choices)
        {
            end = true;
        }
        if (Input.GetButtonDown("Interact") && end)
        {
            end = false;
            mainMusic.SetActive(true);
            amirMusic.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (requireButtonPress)
            {
                icon.enabled = true;
                waitForPress = true;
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
            icon.enabled = false;
        }
    }
    public void Option1() //Well, I was in the train...
    {
        
        theTextBox.currentLine = option1Line;
        theTextBox.endAtLine = option1EndLine;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option3);
        theTextBox.option2.onClick.AddListener(Option4);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "What Society?";
        theTextBox.option2Text.text = "What do I have to do?";
    }
    public void Option2() //Who are you?
    {
        theTextBox.currentLine = option2Line;
        theTextBox.endAtLine = option2EndLine;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option4);
        theTextBox.option2.onClick.AddListener(Option5);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "What do I have to do?";
        theTextBox.option2Text.text = "Sun order?";
    }
    public void Option3() //What Society?
    {
        theTextBox.currentLine = 6;
        theTextBox.endAtLine = 6;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option7);
        theTextBox.option2.onClick.AddListener(Option6);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "What am I supposed to do?";
        theTextBox.option2Text.text = "Where?";

    }
    public void Option4() //What do I have to do?
    {
        theTextBox.currentLine = 26;
        theTextBox.endAtLine = 28;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option8);
        theTextBox.option2.onClick.AddListener(Option9);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "Where is this temple?";
        theTextBox.option2Text.text = "Why me?";

    }
    public void Option5() //Sun Order?
    {
        theTextBox.currentLine = 35;
        theTextBox.endAtLine = 37;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option9);
        theTextBox.option2.onClick.AddListener(Option7);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "Why me?";
        theTextBox.option2Text.text = "What am I supposed to do?";
    }
    public void Option6() //Where?
    {
        theTextBox.currentLine = 9;
        theTextBox.endAtLine = 15;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.choices = false;
        theTextBox.option1Text.text = "ERROR";
        theTextBox.option2Text.text = "ERROR";
    }
    public void Option7() //What am I supposed to do?
    {
        theTextBox.currentLine = 17;
        theTextBox.endAtLine = 24;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.choices = false;
        theTextBox.option1Text.text = "ERROR";
        theTextBox.option2Text.text = "ERROR";
        lastOne = true;
    }
    public void Option8() //Where is this temple?
    {
        theTextBox.currentLine = 8;
        theTextBox.endAtLine = 15;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.choices = false;
        theTextBox.option1Text.text = "ERROR";
        theTextBox.option2Text.text = "ERROR";
        lastOne = true;
    }
    public void Option9() //Why me?
    {
        theTextBox.currentLine = 39;
        theTextBox.endAtLine = 40;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option10);
        theTextBox.option2.onClick.AddListener(Option11);
        theTextBox.choices = true;
        theTextBox.option1Text.text = "...!";
        theTextBox.option2Text.text = "Have you been spying on me?";
        lastOne = false;
    }
    public void Option10() //...!
    {
        theTextBox.currentLine = 42;
        theTextBox.endAtLine = 43;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.choices = false;
        theTextBox.option1Text.text = "ERROR";
        theTextBox.option2Text.text = "ERROR";
        lastOne = true;
    }
    public void Option11() //Have you been spying on me?
    {
        theTextBox.currentLine = 45;
        theTextBox.endAtLine = 46;
        theTextBox.StartCoroutine(theTextBox.TextScroll(theTextBox.textlines[theTextBox.currentLine]));
        theTextBox.DeactivateButtons();
        theTextBox.option1.onClick.AddListener(Option1);
        theTextBox.option2.onClick.AddListener(Option2);
        theTextBox.choices = false;
        theTextBox.option1Text.text = "ERROR";
        theTextBox.option2Text.text = "ERROR";
        lastOne = true;
    }
}
