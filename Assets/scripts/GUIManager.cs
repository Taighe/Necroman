using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using nSCENE;

public class GUIManager : MonoBehaviour 
{
	Text m_soulFragment;
	GameObject m_pauseMenu;
	Image m_lives;
	Player m_player;

	void Awake()
	{
		m_pauseMenu = transform.GetChild (1).gameObject;
		m_lives = transform.GetChild (2).GetComponent<Image> ();
		m_player = GameScene.gameScene.player.GetComponent<Player> ();
		m_soulFragment = transform.GetChild(3).GetComponent<Text>();

	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//guiElements[0].text = "Time " + scene.GetComponent<GameScene>().levelTime / 60;
		m_soulFragment.text = "" + GameScene.gameScene.currentSoulFragments;
		m_pauseMenu.SetActive(Scene.paused);
		int currentLives = m_player.maxRemnants - m_player.m_remnantCount;
		m_lives.fillAmount = (float)currentLives / (float)m_player.maxRemnants; 
	}
}
