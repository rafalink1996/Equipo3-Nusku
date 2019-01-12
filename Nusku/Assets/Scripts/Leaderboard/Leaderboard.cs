using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Leaderboard : MonoBehaviour {
	public static int scoreRox = 4550;
	public static int scoreAmir = 3950;
	public static int scoreHernan = 3550;

	public static Vector2 p1max;
	public static Vector2 p1min;
	public static Vector2 p2max;
	public static Vector2 p2min;
	public static Vector2 p3max;
	public static Vector2 p3min;
	public static Vector2 p4max;
	public static Vector2 p4min;


	RectTransform rectTransform;

	// Use this for initialization
	void Start () {
		

		p1max = new Vector2 (0.9622988f, 0.876f);
		p1min = new Vector2 (0.03770127f, 0.58f);
		p2max = new Vector2 (0.9622988f, 0.6807493f);
		p2min = new Vector2 (0.03770127f, 0.387f);
		p3max = new Vector2 (0.9622988f, 0.5f);
		p3min = new Vector2 (0.03770127f, 0.207f);
		p4max = new Vector2 (0.9622988f, 0.303f);
		p4min = new Vector2 (0.03770127f, 0f);

		rectTransform = GetComponent<RectTransform> ();

		}
	
	// Update is called once per frame
	void Update () {
		

		if (ScoreManager.score > scoreHernan) {
			rectTransform.anchorMax = p3max;
			rectTransform.anchorMin = p3min;
		}

		if (ScoreManager.score > scoreAmir) {
			rectTransform.anchorMax = p2max;
			rectTransform.anchorMin = p2min;
		}

		if (ScoreManager.score > scoreRox) {
			rectTransform.anchorMax = p1max;
			rectTransform.anchorMin = p1min;
		}

	}
}
