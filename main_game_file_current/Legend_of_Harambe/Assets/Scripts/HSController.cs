using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HSController : MonoBehaviour {

	private string secretkey = "911911911";
	public string highScoreURL = "www.ksotebeer.bplaced.net/display.php";
	public string addScoreURL = "www.ksotebeer.bplaced.net/addscore.php?";

	// Use this for initialization
	void Start () {
		//StartCoroutine (GetScores ());
	}
	
	public IEnumerator PostScores(string username, int score, int distance, int bananas){ // change to have arguments string username, int score, int distance, int bananas

		//This connects to a server side php script that will add infor to MySQL DB
		//Supply it with a string representing player's name, score, distance, and bananas
		string hash = MD5.Md5Sum (username + score + distance + bananas + secretkey);

		string post_url = addScoreURL + "username=" + WWW.EscapeURL(username) + "&score=" + score + "&distance=" + distance  + "&bananas=" + bananas + "&hash=" + hash;
		//Post the URL to the site and create a download object to get the result
		WWW hs_post = new WWW (post_url);
		yield return hs_post; // wait until download is done
		print(hs_post.text);
		if (hs_post.error != null) {
			print ("There was an error posting the high score: " + hs_post.error);
		}
	}

	// Get the scores from the mysql db to display in a GUIText.
	public IEnumerator GetScores(){
		WWW hs_get = new WWW (highScoreURL);
		yield return hs_get;
		string results = hs_get.text;

		if (hs_get.error != null) {
			print ("There was an error getting the high score: " + hs_get.error);
		}
		else{
			string scoreTable = hs_get.text;
			string[] parsedScores = scoreTable.Split ('\t','\n');
			int rows = parsedScores.Length/4;
			if(rows != 0){
				string userCol = "Username:\n\n" + parsedScores [0];
				string scoreCol = "Score:\n\n" + parsedScores [1];
				string distanceCol = "Distance:\n\n" + parsedScores [2];
				string bananasCol = "Bananas:\n\n" + parsedScores [3];
				for (int i = 1; i < rows; i++) {
					userCol += '\n' + parsedScores [i * 4];
					scoreCol += '\n' + parsedScores [i * 4 + 1];
					distanceCol += '\n' + parsedScores [i * 4  +2];
					bananasCol += '\n' + parsedScores [i * 4 + 3];
				}
				Text usernameColumn = GameObject.Find ("UsernameText").GetComponent<Text> ();
				Text scoreColumn = GameObject.Find ("ScoreText").GetComponent<Text> ();
				Text distanceColumn = GameObject.Find ("DistanceText").GetComponent<Text> ();
				Text bananasColumn = GameObject.Find ("BananasText").GetComponent<Text> ();
				usernameColumn.text = userCol;
				scoreColumn.text = scoreCol;
				distanceColumn.text = distanceCol;
				bananasColumn.text = bananasCol;
			}
		}
	}
}
