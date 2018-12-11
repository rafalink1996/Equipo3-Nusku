using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {

    public static GameStats stats;
    public Vector2 position;
    public int selDirectionX;
    public int selDirectionY;
    public int health;
    public bool hasGlove;
    public string currentScene;
    SelHealth selHealth;
    public bool hasPlayedDarts;
    public bool hasWonDarts;
	// Use this for initialization
	void Awake () {
        if (stats == null)
        {
            DontDestroyOnLoad(gameObject);
            stats = this;
        }
        else if (stats != this){
            Destroy(gameObject);
        }
        selHealth = FindObjectOfType<SelHealth>();

	}
	
	// Update is called once per frame
	void Update () {
        //health = selHealth.health;
	}
}
