using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;

	public AudioSource coinSoundEffect;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<PlayerControls> () == null)
		{
			return;
		}
		DragonBallCounter.AddPoints (pointsToAdd);


		coinSoundEffect.Play();

		Destroy(gameObject);
	}
}
