using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MouseController : MonoBehaviour {
    //public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;
    private bool dead = false;
    int bananas = 0;
	float timeNow = 0;
	int distance = 0;
    int jumpCount = 2;
    int ID;
    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsground; // to identify what is ground

    public float jumpForce = 420f;   //is now jetpackforce
    bool doubleJump = false;


    void Update () {
		if (dead == false) {
			timeNow = Time.realtimeSinceStartup;
			timeNow = (timeNow * 10);
			distance = (int)timeNow;
		}

		if (dead == true && grounded == true) {
			StartCoroutine (GameOver (3));
		}

        anim.SetInteger("charID", ID);
        //jumps

        /*if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            if (!doubleJump && !grounded)
                doubleJump = true;
        }*/

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
        anim.SetBool("Dead", true);
    }
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        PlayerPrefs.Save();

    }
    void FixedUpdate()
    {
        ID = PlayerPrefs.GetInt("customID", 1);
        anim.SetInteger("charID", ID);

        //Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsground);
        anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;

        anim.SetFloat("verticleSpeed", GetComponent<Rigidbody2D>().velocity.y);

        /*bool AliveHarambe = Input.GetMouseButtonDown(0);
        if ((grounded || !doubleJump && jumpCount <= 2) && AliveHarambe)
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            if (!doubleJump && !grounded)
                doubleJump = true;
           }*/

        if (!dead)
        {
            bool AliveHarambe = Input.GetMouseButtonDown(0);
            if ((grounded || !doubleJump && jumpCount <= 2) && AliveHarambe)
            {
                anim.SetBool("Ground", false);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                if (!doubleJump && !grounded)
                    doubleJump = true;
            }
            Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
            newVelocity.x = forwardMovementSpeed;
            GetComponent<Rigidbody2D>().velocity = newVelocity;

            anim.SetFloat("Speed", forwardMovementSpeed);
            GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocity.x, GetComponent<Rigidbody2D>().velocity.y);
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

	IEnumerator GameOver(float time){
		yield return new WaitForSeconds (time);
		SceneManager.LoadScene ("HarambeDead");
		PlayerPrefs.SetInt ("Distance", distance);
		PlayerPrefs.SetInt ("Bananas", bananas);
	}
}
