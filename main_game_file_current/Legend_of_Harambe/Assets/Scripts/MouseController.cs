using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {
    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;
	float timeNow = 0;
	int distanceNow = 0;

	// Use this for initialization
	void Start () {
		AudioListener.volume = 1.0f;
	}

	void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");
        if (jetpackActive)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));
        }
        Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
        newVelocity.x = forwardMovementSpeed;
        GetComponent<Rigidbody2D>().velocity = newVelocity;
    }
	// Update is called once per frame
	void Update () {
		//if (dead == false) {
			timeNow = Time.timeSinceLevelLoad;
			timeNow = (timeNow * 2);
			distanceNow = (int)timeNow;
		//}
	}
	void DisplayDistance()
	{
		Rect distanceIconRect = new Rect(0, 10, 32, 32);
		//GUI.DrawTexture(coinIconRect, coinIconTexture);                         

		GUIStyle style = new GUIStyle();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.white;

		Rect labelRect = new Rect(distanceIconRect.xMax, distanceIconRect.y, 60, 32);
		GUI.Label(labelRect, distanceNow.ToString() + " meters", style);
	}
	void OnGUI()
	{
		DisplayDistance ();

	}
}
