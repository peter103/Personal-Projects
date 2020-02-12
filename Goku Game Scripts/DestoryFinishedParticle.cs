using UnityEngine;
using System.Collections;

public class DestoryFinishedParticle : MonoBehaviour {

	// Use this for initialization

	private ParticleSystem thisParticleSystem;

	void Start () 
	{
		thisParticleSystem = GetComponent<ParticleSystem> ();	
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (thisParticleSystem.isPlaying) 
			return;
		Destroy (gameObject);
		
	}

    void onBecameInvisible()
    {
        Destroy(gameObject);
    }
}
