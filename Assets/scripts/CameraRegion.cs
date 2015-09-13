using UnityEngine;
using System.Collections;
using nFOLLOWCAMERA;

public class CameraRegion : MonoBehaviour 
{
	public Rect bounds;
	public float size;

	void OnDrawGizmos()
	{
		Debug.DrawLine (bounds.min, new Vector2(bounds.xMax, bounds.yMin)); //Top
		Debug.DrawLine (bounds.min, new Vector2(bounds.xMin, bounds.yMax)); //Left
		Debug.DrawLine (new Vector2(bounds.xMax, bounds.yMin), bounds.max); //Right
		Debug.DrawLine (new Vector2(bounds.xMin, bounds.yMax), bounds.max); //Bottom
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
