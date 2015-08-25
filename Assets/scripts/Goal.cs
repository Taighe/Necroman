using UnityEngine;
using System.Collections;
using nDATACONTROL;
using nSCENE;

public class Goal : MonoBehaviour 
{
	public string scene;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if(GameScene.GetLevelTime() < DataControl.levelData.highScore || DataControl.levelData.highScore == -1)
			{
				DataControl.levelData.highScore = GameScene.GetLevelTime();
			}

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
