using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void OnClickContinue(){
        Time.timeScale = 1f;
        GameObject.Find("Sel").GetComponent<PauseCommand>().enabled = true;
        Destroy(this.gameObject);
    }
    public void OnClickQuit()
    {
        Application.Quit();

    }
    public void OnClickMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
