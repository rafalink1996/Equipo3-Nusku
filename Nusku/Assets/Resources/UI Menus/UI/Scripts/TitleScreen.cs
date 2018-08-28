using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickPlay() {
        GameObject.Destroy(this.gameObject);
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
        GameObject.Destroy(this.gameObject);
        GameObject loadScreen = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/LoadScreen") as GameObject);
        loadScreen.name = "LoadScreen";
        GameObject canvas = GameObject.Find("Canvas");
        loadScreen.transform.parent = canvas.transform;
        loadScreen.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        loadScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
    }
}
