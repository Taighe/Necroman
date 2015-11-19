using UnityEngine;
using System.Collections;

using nSCENE;

public class Rotator : MonoBehaviour 
{
	public float speed;
	public Vector3 rotateAxis;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Scene.paused)
			return;
		Vector3 axis;

		float angle;

		transform.localRotation.ToAngleAxis (out angle, out axis);

		angle += speed;

		transform.RotateAround (transform.position, rotateAxis, speed * Time.deltaTime);
	}
}
