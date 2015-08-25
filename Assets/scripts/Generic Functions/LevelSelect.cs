﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using nDATACONTROL;
using nLEVELDATA;

public class LevelSelect : MonoBehaviour 
{
	public string dataLink;
	LevelData m_data;

	void Start()
	{
		m_data = GameObject.Find (dataLink).GetComponent<LevelData>();
		Button button = GetComponent<Button> ();
		button.interactable = m_data.unlocked;

		//Score
		Text score = transform.GetChild(1).GetComponent<Text>();

		if (m_data.highScore > -1) 
		{
			float finalScore = m_data.highScore/ 60;
			score.text = finalScore + "";
		}
	}

	public void LoadLevel(string scene)
	{
		Application.LoadLevel (scene);
	}
	
}