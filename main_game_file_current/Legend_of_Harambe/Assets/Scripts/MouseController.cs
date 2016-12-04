using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {
    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;
    private bool dead = false;
    private uint bananas = 0;

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
	// Update is called once per frame
	void Update () {
	
	}
}
