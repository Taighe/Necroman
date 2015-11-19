using UnityEngine;
using System.Collections;
using nENTITY;

public class Destructable : Entity 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	new void Update () 
	{
	
	}

	public override void Die ()
	{
		Destroy (gameObject);
	}
}
