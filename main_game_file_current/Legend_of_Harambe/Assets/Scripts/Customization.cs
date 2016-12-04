using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Customization : MonoBehaviour {
	Sprite[] spriteSheet;
	int currentID;
	Image representation;

	// Use this for initialization
	void Start () {
		representation = GameObject.Find("Representation").GetComponent<Image>();
		currentID = PlayerPrefs.GetInt ("customID", 1);
		spriteSheet = Resources.LoadAll<Sprite>("HARAMBE");

		foreach (Sprite S in spriteSheet) {
			if (S.name.Equals("HARAMBE_" +currentID)) {
				representation.sprite = S;
			}
		}
	}
	
	public void changeChar() {
		if (currentID == 1) {
			currentID = 2;
			PlayerPrefs.SetInt("customID", 2);
			PlayerPrefs.Save();
		} 

		else if (currentID == 2) {
			currentID = 3;
			PlayerPrefs.SetInt("customID", 3);
			PlayerPrefs.Save();
		}

		else if (currentID == 3) {
			currentID = 1;
			PlayerPrefs.SetInt("customID", 1);
			PlayerPrefs.Save();
		}

		foreach (Sprite S in spriteSheet) {
			if (S.name.Equals("HARAMBE_"+currentID)) {
				representation.sprite = S;
			}
		}
	}

	void Update()
	{

	}
}
