using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GameObject.Find("Canvas/HUD"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickMenu(){
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }
    public void OnClickQuit()
    {
        Application.Quit();

    }
}
