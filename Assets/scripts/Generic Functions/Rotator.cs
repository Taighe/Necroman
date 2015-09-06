using UnityEngine;
using System.Collections;

using nSCENE;

public class Rotator : MonoBehaviour 
{
	public float speed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Scene.paused)
			return;

		float angle;
		Vector3 axis;

		transform.localRotation.ToAngleAxis (out angle, out axis);

		angle += speed * Time.deltaTime;

		transform.RotateAround (transform.position, new Vector3(0,0,1), speed);
	}
}
