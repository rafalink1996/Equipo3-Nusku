using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickBack()
    {
        GameObject.Destroy(this.gameObject);
        GameObject titleScreen = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/TitleScreen") as GameObject);
        titleScreen.name = "TitleScreen";
        GameObject canvas = GameObject.Find("Canvas");
        titleScreen.transform.parent = canvas.transform;
        titleScreen.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        titleScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
    }

    public void OnClickPlay()
    {
        GameObject.Destroy(this.gameObject);
        GameObject motionIntro = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/MotionIntro") as GameObject);
        motionIntro.name = "MotionIntro";
        GameObject canvas = GameObject.Find("Canvas");
        motionIntro.transform.parent = canvas.transform;
        motionIntro.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        motionIntro.GetComponent<RectTransform>().localPosition = Vector2.zero;
    }

}
