using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{


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
    public string option2;
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

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
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
}
