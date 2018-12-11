using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownMusic : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name != "Town" && SceneManager.GetActiveScene().name != "Darts")
        {
            Destroy(gameObject);
        }
	}
}
