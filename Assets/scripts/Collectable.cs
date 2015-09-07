using UnityEngine;
using System.Collections;
using nSCENE;

public class Collectable : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			GameScene.gameScene.soulFragments += 1;
			Destroy (gameObject);
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
