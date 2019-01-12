using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ScoreManager : MonoBehaviour {

	      // The player's score.
	public static float score;

	Text text;                      // Reference to the Text component.


	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score.

	}


	void Update ()
	{
		score = ShootingRange.score;
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "" + ShootingRange.score;

		if (ShootingRange.score > Leaderboard.scoreRox) {
			GetComponent<Text>().color = Color.yellow;
		}
	}
}

	