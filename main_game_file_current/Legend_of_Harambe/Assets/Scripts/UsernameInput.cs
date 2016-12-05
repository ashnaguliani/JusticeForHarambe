using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UsernameInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var input = gameObject.GetComponent<InputField> ();
		input.onEndEdit.AddListener (SubmitName);
	}

	private void SubmitName(string username){
		int distance = PlayerPrefs.GetInt ("Distance");
		int bananas = PlayerPrefs.GetInt ("Bananas");
		int score = 60 * distance + 40 * bananas;
		HSController HS = new HSController();
		StartCoroutine(HS.PostScores(username,score,distance,bananas));
		StartCoroutine (HS.GetScores ());
	}
}
