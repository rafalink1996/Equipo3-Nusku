using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    public string sceneToLoad;
    public Vector2 destination;
    public int selDirectionX;
    public int selDirectionY;
    Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        if (GetComponent<SpriteRenderer>().enabled == false){
            GetComponent<SpriteRenderer>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Fade");
            GameStats.stats.health = FindObjectOfType<SelHealth>().health;
            FindObjectOfType<PlayerMovement2D>().canMove = false;
        }
    }
    void LoadScene(){
        GameStats.stats.position = destination;
        GameStats.stats.selDirectionX = selDirectionX;
        GameStats.stats.selDirectionY = selDirectionY;
        GameStats.stats.currentScene = sceneToLoad;
        SceneManager.LoadScene(sceneToLoad);
    }
}
