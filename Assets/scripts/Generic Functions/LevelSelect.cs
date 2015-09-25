using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using nDATACONTROL;
using nLEVELDATA;

public class LevelSelect : MonoBehaviour 
{
	public string dataLink;
	public GameObject canvas;
	public EventSystem m_event;
	LevelData m_data;

	void Start()
	{
		if (dataLink == "")
			return;

		m_data = GameObject.Find (dataLink).GetComponent<LevelData>();

		canvas.transform.GetChild (0).gameObject.SetActive (false);

		Button button = GetComponent<Button> ();
		button.interactable = m_data.unlocked;

		//Score
		//Text score = transform.GetChild(1).GetComponent<Text>();
		if (transform.childCount > 1) 
		{
			Text soulFragments = transform.GetChild (2).GetComponent<Text> ();
			soulFragments.text = "Soul Fragments " + m_data.scoreSoulFragments + " / 10";
		}

		if ( m_data.highScore > -1 ) 
		{
			float finalScore = m_data.highScore / 60;
			//score.text = finalScore + "";
		}
	}

	public void ModeSelect()
	{
		GameObject _modeSelect = canvas.transform.GetChild (0).gameObject;
		_modeSelect.SetActive (true);
		m_event.SetSelectedGameObject (_modeSelect.transform.GetChild (0).gameObject);
		Button _timeAttack = _modeSelect.transform.GetChild (1).gameObject.GetComponent<Button> ();
		_timeAttack.interactable = m_data.timeAttackMode;
		canvas.transform.GetChild (0).gameObject.SetActive (true);
		DataControl.control.levelData = m_data;
		m_event.gameObject.SetActive (false);
	}

}