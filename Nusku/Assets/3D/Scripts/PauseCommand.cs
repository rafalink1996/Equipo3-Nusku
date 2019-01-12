using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCommand : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 0f;
            GameObject pauseScreen = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/PauseScreen") as GameObject);
            pauseScreen.name = "PauseScreen";
            GameObject canvas = GameObject.Find("Canvas");
            pauseScreen.transform.parent = canvas.transform;
            pauseScreen.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
            pauseScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
            GetComponent<PauseCommand>().enabled = false;

        }
	}
}
