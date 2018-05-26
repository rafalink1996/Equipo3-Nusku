using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur : MonoBehaviour {

    public int health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0){
            Invoke("Die", 3f);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet"){
            health = health - 10;
        }
    }
    public void Attack(){
        GameObject.Find("Mouth").GetComponent<JurMouth>().JurAttack();
    }
    void Die(){
        Time.timeScale = 0f;
        GameObject winScreen = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/WinScreen") as GameObject);
        winScreen.name = "WinScreen";
        GameObject canvas = GameObject.Find("Canvas");
        winScreen.transform.parent = canvas.transform;
        winScreen.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        winScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
        GetComponent<PauseCommand>().enabled = false;
    }
}
