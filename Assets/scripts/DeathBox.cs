﻿using UnityEngine;
using System.Collections;
using nENTITY;

public class DeathBox : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			collision.gameObject.GetComponent<Entity>().Die();
		}
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
