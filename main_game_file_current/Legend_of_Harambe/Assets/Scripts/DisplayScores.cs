using UnityEngine;
using System.Collections;

public class DisplayScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HSController HS = new HSController();
		StartCoroutine (HS.GetScores ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
