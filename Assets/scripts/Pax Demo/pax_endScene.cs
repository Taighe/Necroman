using UnityEngine;
using System.Collections;

public class pax_endScene : MonoBehaviour 
{
	public float timer;
	public float delay;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += 1.0f *Time.deltaTime;
		if (timer > delay) 
		{
			Application.LoadLevel("lvl1_area1");
		}
	}
}
