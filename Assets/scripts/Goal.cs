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
		DataControl.control.levelData.scoreSoulFragments = GameScene.gameScene.currentSoulFragments;
		GameObject _collectable = GameScene.gameScene.gameObject.transform.GetChild (1).gameObject;

		for (int i = 0; i < GameScene.gameScene.totalSoulFragments; i++) 
		{
			DataControl.control.levelData.collectedSouls[i] = _collectable.transform.GetChild(i).GetComponent<Collectable>().IsCollected;
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
