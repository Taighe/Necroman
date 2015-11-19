using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour 
{
	public Rect bounds;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnDrawGizmos()
	{
		Debug.DrawLine (bounds.min, new Vector2(bounds.xMax, bounds.yMin)); //Top
		Debug.DrawLine (bounds.min, new Vector2(bounds.xMin, bounds.yMax)); //Left
		Debug.DrawLine (new Vector2(bounds.xMax, bounds.yMin), bounds.max); //Right
		Debug.DrawLine (new Vector2(bounds.xMin, bounds.yMax), bounds.max); //Bottom
	}
}
