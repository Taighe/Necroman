
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using nSCENE;

public enum GUIState
{
	PAUSED,
	GAMEOVER
}

public class GUIManager : MonoBehaviour 
{
	public Text m_soulFragment;
	public GameObject m_pauseMenu;
	public Image m_lives;
	public GameObject m_clock;
	public GameObject m_gameOverMenu;
	public GameObject m_controlMenu;
	public GameObject m_currentMenu;
	public GameObject m_hud;
	public EventSystem m_eventSystem;
    public Text m_score;
    public Image m_vig;
	
	Player m_player;
	EventSystem m_event;
	float startTime;
	GUIState m_guiState;

	delegate void GUI();
	GUI m_gui;
	
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
		m_currentMenu = m_controlMenu;
	}

	public void Retry()
	{
		Application.LoadLevel (GameScene.gameScene.sceneName);
        Scene.paused = false;
        Scene.buttonPressed = true;
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
        m_vig.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () 
	{
		HUD ();
		ControlsMenu ();

		m_pauseMenu.SetActive(Scene.paused);

		if(GameScene.gameScene.IsGameOver() )
		{
			m_currentMenu = m_gameOverMenu;
			//m_eventSystem.SetSelectedGameObject(m_currentMenu.transform.GetChild(1).gameObject);
		}
	}

	void HUD()
	{
		int _seconds = (int)(GameScene.gameScene.levelTime % 60.0f);
		
		int _minutes = (int)GameScene.gameScene.levelTime / 60;
		string _time = string.Format("{0:00}:{1:00}", _minutes, _seconds);
		m_clock.GetComponent<Text> ().text = _time;
		
		m_soulFragment.text = "" + GameScene.gameScene.currentSoulFragments + "/10";

        string _score = GameScene.gameScene.score.ToString("00000");
        m_score.text = "" + _score;

		int currentLives = m_player.m_lives;
		m_lives.rectTransform.sizeDelta = new Vector2 (currentLives * 2, 2);
       
        Color red = new Color(1,0,0);
        Color black = new Color(0, 0, 0);

        m_vig.color = black;

        if (currentLives <= 0)
        {
            m_vig.color = Color.Lerp(black, red, Mathf.Sin(Time.time * 3.5f));
        }
	}

	void ControlsMenu()
	{
		if (m_currentMenu == m_controlMenu) 
		{
			if(Input.GetButtonDown("Cancel"))
			{
				m_currentMenu = m_hud;
			}
		}
	}
	
}