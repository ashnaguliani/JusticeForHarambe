using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {
    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;
    private bool dead = false;
    private uint bananas = 0;
	float timeNow = 0;
	int distance = 0;

	void Update () {
		if (dead == false) {
			timeNow = Time.realtimeSinceStartup;
			timeNow = (timeNow * 10);
			distance = (int)timeNow;
		}
	}

    void CollectBanana(Collider2D bananaCollider)
    {
        bananas++;
        Destroy(bananaCollider.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("bananas"))
            CollectBanana(collider);
        else
            HitByLaser(collider);
    }
    void HitByLaser(Collider2D laserCollider)
    {
        dead = true;
    }
	// Use this for initialization
	void Start () {
	
	}
	void FixedUpdate()
    {
        bool jetpackActive = Input.GetButton("Fire1");

        jetpackActive = jetpackActive && !dead;

        if (jetpackActive)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));
        }
        if (!dead)
        {
            Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
            newVelocity.x = forwardMovementSpeed;
            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
        //UpdateGroundedStatus();
        //AdjustJetpack(jetpackActive);*/
     }
	void OnGUI()
	{
		DisplayBananasCount();

		DisplayDistance ();
	}

	void DisplayBananasCount()
	{
		Rect coinIconRect = new Rect(5, 10, 32, 32);
		//GUI.DrawTexture(coinIconRect, coinIconTexture);                         

		GUIStyle style = new GUIStyle();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.white;

		Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
		GUI.Label(labelRect, bananas.ToString() + " bananas", style);
	}

	void DisplayDistance()
	{
		Rect distanceIconRect = new Rect(925, 10, 32, 32);

		GUIStyle style = new GUIStyle();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.white;

		Rect labelRect = new Rect(distanceIconRect.xMax, distanceIconRect.y, 60, 32);
		GUI.Label(labelRect, distance.ToString() + " meters", style);
	}
}
