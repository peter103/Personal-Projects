using UnityEngine;
using System.Collections;

public class EnergyBallController : MonoBehaviour {


	public float speed;

	public PlayerControls player;

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	public int killingPoints;

	public LayerMask whatIsGround;

	public float timeLeft;

	Collider collider;

	public float rotationSpeed;

	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<PlayerControls>();
		if (player.transform.localScale.x < 0) 
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody2D> ().velocity = new Vector2(speed,GetComponent<Rigidbody2D>().velocity.y);

		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed * 20;
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Enemy") 
		{
			Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			ScoreManager.AddPoints (killingPoints);
		}



		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);

		//timeLeft -= Time.deltaTime;


		//Destroy (gameObject);

	}

}
