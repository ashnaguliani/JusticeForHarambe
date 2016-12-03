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
		currentID = 1;
		spriteSheet = Resources.LoadAll<Sprite>("HARAMBE");
	}
	
	public void changeChar() {
		if (currentID == 1) {
			currentID = 2;
		} 

		else if (currentID == 2) {
			currentID = 1;
		}

		foreach (Sprite S in spriteSheet) {
			if (S.name.Equals("HARAMBE_"+currentID)) {
				representation.sprite = S;
			}
		}
	}
}
