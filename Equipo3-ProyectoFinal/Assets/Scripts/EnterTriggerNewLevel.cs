using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterTriggerNewLevel : MonoBehaviour {



	private void OnTriggerEnter(Collider other)
	{
        other.GetComponent<LevelChanger2>().FadeToLevel(2);
	}



	// Update is called once per frame
	void Update () {

       
	}
}
