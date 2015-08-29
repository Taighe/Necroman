using UnityEngine;
using System.Collections;
using nDATACONTROL;

public class Collectable : MonoBehaviour 
{

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			DataControl.levelData.soulFragment = true;
			Destroy (this.gameObject);
		}
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
