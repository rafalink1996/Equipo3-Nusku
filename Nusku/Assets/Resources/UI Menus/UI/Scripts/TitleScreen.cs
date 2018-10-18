using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    public Button start;
	// Use this for initialization
	void Start () {
        start.Select();
        start.OnSelect(null);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnClickPlay() {
        gameObject.SetActive(false);
        GameObject motionIntro = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/MotionIntro") as GameObject);
        motionIntro.name = "MotionIntro";
        GameObject canvas = GameObject.Find("Canvas");
        motionIntro.transform.parent = canvas.transform;
        motionIntro.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        motionIntro.GetComponent<RectTransform>().localPosition = Vector2.zero;
    }
    public void OnClickQuit() {
        Application.Quit();

    }
    public void OnClickLoad() {
        gameObject.SetActive(false);
        GameObject loadScreen = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/LoadScreen") as GameObject);
        loadScreen.name = "LoadScreen";
        GameObject canvas = GameObject.Find("Canvas");
        loadScreen.transform.parent = canvas.transform;
        loadScreen.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        loadScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
    }
}
