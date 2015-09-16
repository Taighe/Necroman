﻿using UnityEngine;
using System.Collections;
using nDATACONTROL;
using nSCENE;
using nCOLLECTABLE;

public class Goal : MonoBehaviour 
{
	public string scene;
	public float delay;
	float m_timer;
	bool m_IsOpen;

	Animator m_animator;

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if(Input.GetAxis("Vertical") > 0 )
			{
				m_IsOpen = true;
				m_animator.SetBool("Open", true);
			}
		}
	}

	public void EndLevel()
	{
		if(m_timer >= delay)
		{
			DataControl.control.levelData.scoreSoulFragments = GameScene.gameScene.currentSoulFragments;
			GameObject _collectable = GameScene.gameScene.gameObject.transform.GetChild (1).gameObject;

			for (int i = 0; i < GameScene.gameScene.totalSoulFragments; i++) 
			{
				DataControl.control.levelData.collectedSouls[i] = _collectable.transform.GetChild(i).GetComponent<Collectable>().IsCollected;
			}

			DataControl.control.Save();
			
			Application.LoadLevel(scene);
		}

	}
	
	// Use this for initialization
	void Start () 
	{
		m_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_IsOpen == true) 
		{
			m_timer += Time.deltaTime * 1.0f;
			GameScene.gameScene.player.GetComponent<Player>().disableControl = true;
		}

		EndLevel();
	}
}
