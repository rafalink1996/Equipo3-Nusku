using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreAmir : MonoBehaviour {
	
	RectTransform rectTransform;

	// Use this for initialization
	void Start () {

		rectTransform = GetComponent<RectTransform> ();
	}

	// Update is called once per frame
	void Update () {


			if (ScoreManager.score > Leaderboard.scoreAmir) {
			rectTransform.anchorMax = Leaderboard.p3max;
			rectTransform.anchorMin = Leaderboard.p3min;
		}


	}
}

