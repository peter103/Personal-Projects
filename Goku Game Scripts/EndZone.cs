using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {
	public int Level;
    public float tranTime;
    public AudioSource tranSoundEffect;
    private bool activate = false;

    void Update()
    {
        if (activate == true)
        {
            tranTime -= Time.deltaTime;
        }
        if (tranTime < 0 && activate == true)
        {
            Application.LoadLevel(Level);
            activate = false;
        }
    }

    void OnTriggerEnter2D(Collider2D otherObject)
	{
		if (otherObject.tag == "Player") {
            //Destroy (otherObject.gameObject);
            //Destroy (gameObject);

            activate = true;

            Destroy(otherObject.gameObject);

            tranSoundEffect.Play();

            /*if (tranTime < 0)
            {
                Application.LoadLevel(Level);
                activate = false;
            }*/
		}

	}
}
