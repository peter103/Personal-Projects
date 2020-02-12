using UnityEngine;
using System.Collections;

public class MenuCamera : MonoBehaviour {

    public float moveCamVelocity;
    public float MoveTime;


    // Use this for initialization

	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = 1f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveCamVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }


    
}
