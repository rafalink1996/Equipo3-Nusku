using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreRoxx : MonoBehaviour {
	
	RectTransform rectTransform;

	// Use this for initialization
	void Start () {

		rectTransform = GetComponent<RectTransform> ();
	}

	// Update is called once per frame
	void Update () {


			if (ScoreManager.score > Leaderboard.scoreRox) {
			rectTransform.anchorMax = Leaderboard.p2max;
			rectTransform.anchorMin = Leaderboard.p2min;
		}
	}
}

