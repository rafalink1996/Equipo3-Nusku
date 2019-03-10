using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToDarts : MonoBehaviour {

    public string characterName;
    public Sprite characterImage;
    public TextAsset theText;
    public int startLine;
    public int endLine;
    public TextBoxManager theTextBox;
    public bool destroyWhenActivated;
    public bool requireButtonPress;
    public bool hasOptions;
    public string opttion1;
    public int opttion1Line, opttion1EndLine;
    public string opttion2;
    public int opttion2Line, opttion2EndLine;
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
        if (GameStats.stats.hasWonDarts){
            Destroy(gameObject);
        }
        if (waitForPress && Input.GetButtonDown("Interact"))
        {
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

            if (destroyWhenActivated)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<EdgeCollider2D>().enabled = false;
            }
            if (hasOptions == true)
            {
                theTextBox.choices = true;
                theTextBox.option1Text.text = opttion1;
                theTextBox.option2Text.text = opttion2;
                theTextBox.option1.onClick.AddListener(Opttion1);
                theTextBox.option2.onClick.AddListener(Opttion2);
                //theTextBox.option1.enabled = true;
                //theTextBox.option2.enabled = true;
                //theTextBox.option1Text.enabled = true;
                //theTextBox.option2Text.enabled = true;

            }
            else
            {
                opttion1 = null;
                opttion2 = null;
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
                theTextBox.option1Text.text = opttion1;
                theTextBox.option2Text.text = opttion2;
                theTextBox.option1.onClick.AddListener(Opttion3);
                theTextBox.option2.onClick.AddListener(Opttion4);
                //theTextBox.option1.enabled = true;
                //theTextBox.option2.enabled = true;
                //theTextBox.option1Text.enabled = true;
                //theTextBox.option2Text.enabled = true;

            }
            else
            {
                opttion1 = null;
                opttion2 = null;
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
    public void Opttion1() //Yes
    {
        theTextBox.DisableTextBox();
        theTextBox.DeactivateButtons();
        GetComponent<Animator>().SetTrigger("Fade");
        theTextBox.choices = false;
        GameStats.stats.hasPlayedDarts = true;
        GameStats.stats.dartsTries = GameStats.stats.dartsTries + 1;

    }
    public void Opttion2() //No
    {
        theTextBox.DisableTextBox();
        theTextBox.DeactivateButtons();
        theTextBox.choices = false;

    }
    public void Opttion3() //Yes
    {
        theTextBox.DisableTextBox();
        theTextBox.DeactivateButtons();
        SceneManager.LoadScene("Darts");
        theTextBox.choices = false;

    }
    public void Opttion4() //No
    {
        theTextBox.DisableTextBox();
        theTextBox.DeactivateButtons();
        GetComponent<Animator>().SetTrigger("Fade");
        theTextBox.choices = false;


    }
    public void Change()
    {
        
            SceneManager.LoadScene("Darts");


    }
}