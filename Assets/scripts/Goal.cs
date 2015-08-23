using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour 
{
	public string scene;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Application.LoadLevel(scene);
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
