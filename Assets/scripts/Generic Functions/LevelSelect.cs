using UnityEngine;
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
		if (dataLink == "")
			return;

		m_data = GameObject.Find (dataLink).GetComponent<LevelData>();

		Button button = GetComponent<Button> ();
		button.interactable = m_data.unlocked;

		//Score
		Text score = transform.GetChild(1).GetComponent<Text>();

		Text soulFragments = transform.GetChild(2).GetComponent<Text>();

		soulFragments.text = "Soul Fragments " + m_data.scoreSoulFragments + " / 10";

		if (m_data.highScore > -1) 
		{
			float finalScore = m_data.highScore/ 60;
			score.text = finalScore + "";
		}
	}

	public void LoadLevel(string scene)
	{
		DataControl.control.levelData = m_data;
		Application.LoadLevel (scene);
	}
	
}