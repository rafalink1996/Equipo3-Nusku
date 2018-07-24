using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderTest : MonoBehaviour {

    public Slider sliderHealth;
    Animator anim;
    SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sliderHealth = GameObject.Find("Canvas/HUD/Health").GetComponent<Slider>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        //sliderHealth.value = GetComponent<PlayerMovement>().health;
        if (sliderHealth.value <= 0){
            anim.SetBool("Dead", true);
            GetComponent<PlayerMovement>().enabled = false;
            GameObject.Find("Sel/Glove").GetComponent<Glove>().enabled = false;
            GameObject.Find("Footsteps").active = false;
            GameObject.Find("Damage").active = false;
            Invoke("GameOver", 3f); 

        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            sliderHealth.value = sliderHealth.value - 20;
            spriteRenderer.color = new Color(255, 0, 0);
            Invoke("ChangeColorBack", 0.5f); 

        }
        if (collision.collider.gameObject.name == "Respawn Zone"){
            sliderHealth.value = sliderHealth.value - 10;
            spriteRenderer.color = new Color(255, 0, 0);
            Invoke("ChangeColorBack", 1.5f);
        }
    }
    void GameOver (){
        Time.timeScale = 0f;
        GameObject gameOverScreen = GameObject.Instantiate(Resources.Load("UI Menus/UI/Screens/GameOverScreen") as GameObject);
        gameOverScreen.name = "GameOverScreen";
        GameObject canvas = GameObject.Find("Canvas");
        gameOverScreen.transform.parent = canvas.transform;
        gameOverScreen.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        gameOverScreen.GetComponent<RectTransform>().localPosition = Vector2.zero;
        GetComponent<PauseCommand>().enabled = false;

    }
    void ChangeColorBack()
    {
        spriteRenderer.color = new Color(255, 255, 255);
    }

}
