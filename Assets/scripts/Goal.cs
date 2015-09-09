using UnityEngine;
using System.Collections;
using nDATACONTROL;
using nSCENE;
using nCOLLECTABLE;

public class Goal : MonoBehaviour 
{
	public string scene;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{

			EndLevel();

			DataControl.control.Save();

			Application.LoadLevel(scene);
		}
	}

	void EndLevel()
	{
		if(GameScene.gameScene.currentSoulFragments > DataControl.levelData.scoreSoulFragments)
		{
			DataControl.levelData.scoreSoulFragments = GameScene.gameScene.currentSoulFragments;
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
