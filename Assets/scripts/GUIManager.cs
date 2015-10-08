
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
	public GameObject m_clock;
	public GameObject m_controlsMenu;
	public GameObject m_currentMenu;
	
	Player m_player;
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

	public void Resume()
	{
		Scene.paused = false;
		Scene.buttonPressed = true;
	}
	
	public void Controls()
	{
		m_pauseMenu.SetActive (false);
		m_currentMenu = m_controlsMenu;
	}
	
	public void Quit()
	{
		Scene.paused = false;
		Scene.buttonPressed = true;
		Application.LoadLevel("splash_screen");
	}

	// Use this for initialization
	void Start () 
	{
		startTime = GameScene.gameScene.levelTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//m_clock.SetActive (nDATACONTROL.DataControl.control.levelData.timeAttackMode);

		if (m_currentMenu == m_controlsMenu && Input.GetButtonDown("Cancel")) 
		{
			m_currentMenu = m_pauseMenu;
			m_controlsMenu.SetActive(false);
		}

		int _seconds = (int)(GameScene.gameScene.levelTime % 60.0f);

		int _minutes = (int)GameScene.gameScene.levelTime / 60;
		string _time = string.Format("{0:00}:{1:00}", _minutes, _seconds);
		m_clock.GetComponent<Text> ().text = _time;

		m_soulFragment.text = "" + GameScene.gameScene.currentSoulFragments + "/ 10";
		m_currentMenu.SetActive(Scene.paused);
		int currentLives = m_player.m_lives;
		m_lives.rectTransform.sizeDelta = new Vector2 (currentLives * 2, 2);
	}


}