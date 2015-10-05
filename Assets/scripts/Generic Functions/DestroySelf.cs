using UnityEngine;
using System.Collections;

// For Particle Systems

public class DestroySelf : MonoBehaviour 
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
		timer += 1.00f * Time.deltaTime; 
		if (timer >= delay) 
		{
			Destroy (this.gameObject);
		}
	}
}
