using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {


	public Transform[] background;
	private float[] parallaxScales;
	public float smoothing;

	private Transform cam;
	private Vector3 previousCamPos; 

	// Use this for initialization
	void Start () 
	{
		cam = Camera.main.transform;

		previousCamPos = cam.position;

		parallaxScales = new float[background.Length];

		for (int i = 0; i < background.Length; i++) 
		{
			parallaxScales [i] = background [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		for(int i = 0; i < background.Length; i++)
		{
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales [i];

			float backgroundTargetPosX = background [i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, background [i].position.y, background [i].position.x);

			background [i].position = Vector3.Lerp (background[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

		}
		previousCamPos = cam.position;
	
	}
}
