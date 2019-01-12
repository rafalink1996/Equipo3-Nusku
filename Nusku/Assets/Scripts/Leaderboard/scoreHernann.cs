using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreHernann : MonoBehaviour {
	
	RectTransform rectTransform;


	// Use this for initialization
	void Start () {

		rectTransform = GetComponent<RectTransform> ();
		}

	// Update is called once per frame
	void Update () {


		if (ScoreManager.score > Leaderboard.scoreHernan) {
			rectTransform.anchorMax = Leaderboard.p4max;
			rectTransform.anchorMin = Leaderboard.p4min;
		}

	}
}
