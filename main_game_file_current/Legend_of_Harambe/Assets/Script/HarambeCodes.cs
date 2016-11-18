using UnityEngine;
using System.Collections;

public class HarambeCodes : MonoBehaviour {

    public float forwardMovementSpeed = 3.0f;
    //Vector2 newVelocity = rigidbody2D.velocity;

    public float MaxSpeed = 10f;
    bool faceRight = true;

    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsground; // to identify what is ground

    public float jumpForce = 700f;
    bool doubleJump = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        //
        Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
        newVelocity.x = forwardMovementSpeed;
        GetComponent<Rigidbody2D>().velocity = newVelocity;
        //
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsground);
        anim.SetBool("Ground", grounded);

        if (grounded)
            doubleJump = false;

        anim.SetFloat("verticleSpeed", GetComponent<Rigidbody2D>().velocity.y);

        if (!grounded)
            return;
        float move = Input.GetAxis("Horizontal");
        //anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("Speed", forwardMovementSpeed);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(move * MaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocity.x, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 &&!faceRight)
            Flip();
        else if (move < 0 && faceRight)
               Flip();
    }

    void Update()
    {
        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            if(!doubleJump && !grounded)
                doubleJump = true;
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
