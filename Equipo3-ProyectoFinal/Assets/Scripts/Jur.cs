using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur : MonoBehaviour {

    public int health = 100;
    Animator anim;
    public AudioSource dead;
    public AudioSource splash;
    public AudioSource jurdamage;
    public AudioSource damagehiss;
    SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0){
            
            anim.SetTrigger("Dead");
            Invoke("Die", 3f);
            dead.enabled = true;
            splash.enabled = true;
            

        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet"){
            health = health - 5;
            jurdamage.Play();
            damagehiss.Play();
            spriteRenderer.color = new Color(255, 0, 0);
            Invoke("ChangeColorBack", 0.5f); 

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
        GameObject.Find("Sel").GetComponent<PauseCommand>().enabled = false;
        

    }
    void ChangeColorBack (){
        spriteRenderer.color = new Color(255, 255, 255);
    }
}
