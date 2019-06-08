using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownMusic : MonoBehaviour {

    public static TownMusic music;
	// Use this for initialization
	void Awake () {
        if (music == null)
        {
            DontDestroyOnLoad(gameObject);
            music = this;
        }
        else if (music != this)
        {
            Destroy(gameObject);
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name != "Town" && SceneManager.GetActiveScene().name != "Darts")
        {
            Destroy(gameObject);
        }
	}
}
