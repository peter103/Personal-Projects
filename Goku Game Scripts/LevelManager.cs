using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization

	public GameObject currentCheckpoint;

	private PlayerControls player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public int pointPenaltyOnDeath;

	public float respawnDelay;

    private CameraController camera;

	private float gravityStore;

	void Start () 
	{
		player = FindObjectOfType<PlayerControls> ();
		gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
        camera = FindObjectOfType<CameraController>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		StartCoroutine (RespawnPlayerCo());
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<SpriteRenderer>().enabled = false;
        camera.isFollowing = false;
		//gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;// This will set the gravity scale to 0 after the play die.
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		ScoreManager.AddPoints (-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore; // This will set the gravity scale back to 5 after the player has respawned.
        player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.GetComponent<SpriteRenderer>().enabled = true;
        camera.isFollowing = true;
        Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}


}
