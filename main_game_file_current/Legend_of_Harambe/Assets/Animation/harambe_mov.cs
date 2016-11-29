using UnityEngine;
using System.Collections;

public class harambe_mov : MonoBehaviour {
    public float forwardMovementSpeed = 3.0f;
    public float MaxSpeed = 10f;

    Animator anim;

    public float jumpForce = 700f;
    bool doubleJump = false;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
    void FixedUpdate()
    {
        Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
        newVelocity.x = forwardMovementSpeed;
        GetComponent<Rigidbody2D>().velocity = newVelocity;

        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", forwardMovementSpeed);
        GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocity.x, GetComponent<Rigidbody2D>().velocity.y);

    }
    // Update is called once per frame
    void Update () {
	
	}
    
}
