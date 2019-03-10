using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownsfolkDialogueImages : MonoBehaviour
{
    public Sprite Medri;
    public Sprite Mila;
    public Sprite Rox;
    public Sprite Rafa;
    public Sprite Loco;
    public Sprite Roddick;
    public Sprite Lora;
    public Sprite Sel;
    public Sprite Rod;

    public TextBoxManager theTextBox;

    // Start is called before the first frame update
    void Start()
    {
        theTextBox = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Medri
        if (theTextBox.currentLine == 1 || theTextBox.currentLine == 2 || theTextBox.currentLine == 4 || theTextBox.currentLine == 5 || theTextBox.currentLine ==  6|| theTextBox.currentLine == 7 || theTextBox.currentLine == 8 || theTextBox.currentLine == 11 || theTextBox.currentLine == 13 || theTextBox.currentLine == 15 || theTextBox.currentLine == 17){
            theTextBox.image = Medri;
            theTextBox.characterName.text = "Medrinov";
        }
        if (theTextBox.currentLine == 20 || theTextBox.currentLine == 21 || theTextBox.currentLine == 22)
        {
            theTextBox.image = Mila;
            theTextBox.characterName.text = "Lena";
        }
        if (theTextBox.currentLine == 25 || theTextBox.currentLine == 26 || theTextBox.currentLine == 27 || theTextBox.currentLine == 28)
        {
            theTextBox.image = Loco;
            theTextBox.characterName.text = "Forridge";
        }
        if (theTextBox.currentLine == 31 || theTextBox.currentLine == 35 || theTextBox.currentLine == 38)
        {
            theTextBox.image = Roddick;
            theTextBox.characterName.text = "Roddick";
        }
        if (theTextBox.currentLine == 36)
        {
            theTextBox.image = Lora;
            theTextBox.characterName.text = "Lora";
        }
        if (theTextBox.currentLine == 41 || theTextBox.currentLine == 42 || theTextBox.currentLine == 45 || theTextBox.currentLine == 48 || theTextBox.currentLine == 49 || theTextBox.currentLine == 50)
        {
            theTextBox.image = Rox;
            theTextBox.characterName.text = "Rox";
        }
        if (theTextBox.currentLine == 51)
        {
            theTextBox.image = Rod;
            theTextBox.characterName.text = "";
        }
        if (theTextBox.currentLine == 3 || theTextBox.currentLine == 12 || theTextBox.currentLine == 14 || theTextBox.currentLine == 16)
        {
            theTextBox.image = Sel;
            theTextBox.characterName.text = "Sel";
        }
    }
}
