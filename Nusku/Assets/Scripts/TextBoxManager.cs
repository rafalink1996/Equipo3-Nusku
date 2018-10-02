using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{

    public GameObject textBox;
    public Text theText;
    public Text characterName;
    public Image characterImage;
    public TextAsset textFile;
    public Sprite image;
    public bool choices;
    public Button option1;
    public Text option1Text;
    //public int option1Line;
    //public int option1EndLine;
    public Button option2;
    public Text option2Text;
    public string[] textlines;
    public int currentLine;
    public int endAtLine;
    public PlayerMovement2D player;
    public bool isActive;
    public bool stopPlayerMovement;
    bool isTyping = false;
    bool cancelTyping = false;
    public float typeSpeed;
    AudioSource audioSource;
    public GameObject HUD;
    int selectButtons = 0;
    bool buttonSelected;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerMovement2D>();
        audioSource = GetComponent<AudioSource>();
        if (textFile != null)
        {
            textlines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textlines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

        option1.Select();
        option1.OnSelect(null);
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }
        if (image != null)
        {
            characterImage.sprite = image;
        }
        else
        {
            characterImage.sprite = null;
        }

        //theText.text = textlines[currentLine];

        if (Input.GetButtonDown("Interact"))
        {
            if (!isTyping)
            {
                currentLine += 1;


                if (currentLine > endAtLine && !choices)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textlines[currentLine]));
                }
            }
            else if (isTyping == !cancelTyping)
            {
                cancelTyping = true;
            }
        }
        if (choices)
        {
            if (!isTyping && currentLine == endAtLine)
            {
                ActivateButtons();
                selectButtons += 1;

            }
        }
        //if (selectButtons >= 2 || selectButtons <= 5)
        //{
        //    option1.Select();
        //    option1.OnSelect(null);
        //}

    }

    public IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
            audioSource.Play();
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
        StartCoroutine(TextScroll(textlines[currentLine]));
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.canMove = true;
        option1.enabled = false;
        option2.enabled = false;
        option1Text.enabled = false;
        option2Text.enabled = false;

    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textlines = new string[1];
            textlines = (theText.text.Split('\n'));
        }
    }
    public void ActivateButtons()
    {
        option1.enabled = true;
        option2.enabled = true;
        option1Text.enabled = true;
        option2Text.enabled = true;
 
    }
}
