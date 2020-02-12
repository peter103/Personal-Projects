using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    // Use this for initialization
    public float moveSpeed;
    public float jumpHeight;
	private float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
	public static bool shoot;

	private Animator anim;

    public Transform firePoint;

    public GameObject energyBall;
    //public AudioSource ChargeSoundEffect;


    public float shotDelay;
	private float shotDelayCounter;

    public AudioSource jumpSoundEffect;


    void Start ()
    {
		anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


    }

	// Update is called once per frame
	void Update ()
    {

		moveVelocity = 0f;

		if (Input.GetKeyDown(KeyCode.X) && grounded)
        {
            jumpSoundEffect.Play();
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
        }

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D>().velocity.y);




		anim.SetBool("Grounded", grounded);

		anim.SetFloat ("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		anim.SetBool("Shoot", shoot);

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


		if (Input.GetKeyDown(KeyCode.Z) && grounded)
        {
			anim.SetTrigger ("Shoot");
            Instantiate(energyBall, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
        }

		if(Input.GetKeyDown(KeyCode.Z))
		{
			shotDelayCounter -= Time.deltaTime;
			if(shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				Instantiate(energyBall, firePoint.position, firePoint.rotation);

			}
		}

    }
}
