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
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Fade");
            FindObjectOfType<PlayerMovement2D>().canMove = false;
        }
    }
    void LoadScene(){
        GameStats.stats.position = destination;
        GameStats.stats.selDirectionX = selDirectionX;
        GameStats.stats.selDirectionY = selDirectionY;
        SceneManager.LoadScene(sceneToLoad);
    }
}
