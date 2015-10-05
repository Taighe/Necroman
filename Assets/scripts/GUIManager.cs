using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using nSCENE;

public class GUIManager : MonoBehaviour 
{
	public Text m_soulFragment;
	public GameObject m_pauseMenu;
	public Image m_lives;
	Player m_player;
	public GameObject m_clock;
	EventSystem m_event;
	float startTime;

	void Awake()
	{
		//m_clock = transform.GetChild (0).gameObject;
		//m_pauseMenu = transform.GetChild (1).gameObject;
		//m_lives = transform.GetChild (2).GetComponent<Image> ();

		m_player = GameScene.gameScene.player.GetComponent<Player> ();
		//m_soulFragment = transform.GetChild (3).GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () 
	{
		startTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//m_clock.SetActive (nDATACONTROL.DataControl.control.levelData.timeAttackMode);
		float _levelTimeData = GameScene.gameScene.levelTime - startTime;

		if (_levelTimeData >= 60)
			startTime = GameScene.gameScene.levelTime;

		int _minutes = (int)GameScene.gameScene.levelTime / 60;
		string _time = string.Format("{0:00}:{1:00}", _minutes, _levelTimeData);
		m_clock.GetComponent<Text> ().text = _time;

		m_soulFragment.text = "" + GameScene.gameScene.currentSoulFragments + "/ 10";
		m_pauseMenu.SetActive(Scene.paused);
		int currentLives = m_player.maxRemnants - m_player.m_remnantCount;
		m_lives.rectTransform.sizeDelta = new Vector2 (currentLives * 2, 2);
	}
}